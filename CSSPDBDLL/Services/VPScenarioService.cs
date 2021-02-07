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
using System.IO;
using System.Threading;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class VPScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public VPScenarioLanguageService _VPScenarioLanguageService { get; private set; }
        public VPAmbientService _VPAmbientService { get; private set; }
        public VPResultService _VPResultService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public VPScenarioService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _VPScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, User);
            _VPAmbientService = new VPAmbientService(LanguageRequest, User);
            _VPResultService = new VPResultService(LanguageRequest, User);
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
        public string VPScenarioModelOK(VPScenarioModel vpScenarioModel)
        {
            string retStr = FieldCheckNotZeroInt(vpScenarioModel.InfrastructureTVItemID, ServiceRes.InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckNotNullAndMinMaxLengthString(vpScenarioModel.VPScenarioName, ServiceRes.VPScenarioName, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = _BaseEnumService.ScenarioStatusOK(vpScenarioModel.VPScenarioStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckNotNullBool(vpScenarioModel.UseAsBestEstimate, ServiceRes.UseAsBestEstimate);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.EffluentFlow_m3_s, ServiceRes.EffluentFlow_m3_s, 0.0f, 100000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeInt(vpScenarioModel.EffluentConcentration_MPN_100ml, ServiceRes.EffluentConcentration_MPN_100ml, 0, 15000000);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.FroudeNumber, ServiceRes.FroudeNumber, 0.0f, 10000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.PortDiameter_m, ServiceRes.PortDiameter_m, 0.0f, 100.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.PortDepth_m, ServiceRes.PortDepth_m, 0.0f, 1000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.PortElevation_m, ServiceRes.PortElevation_m, 0.0f, 1000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.VerticalAngle_deg, ServiceRes.VerticalAngle_deg, -90.0f, 90.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.HorizontalAngle_deg, ServiceRes.HorizontalAngle_deg, -180.0f, 180.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeInt(vpScenarioModel.NumberOfPorts, ServiceRes.NumberOfPorts, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.PortSpacing_m, ServiceRes.PortSpacing_m, 0.0f, 10000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.AcuteMixZone_m, ServiceRes.AcuteMixZone_m, 0.0f, 1000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.ChronicMixZone_m, ServiceRes.ChronicMixZone_m, 0.0f, 50000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.EffluentSalinity_PSU, ServiceRes.EffluentSalinity_PSU, 0.0f, 35.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.EffluentTemperature_C, ServiceRes.EffluentTemperature_C, 0.0f, 35.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(vpScenarioModel.EffluentVelocity_m_s, ServiceRes.EffluentVelocity_m_s, 0.0f, 100.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = _BaseEnumService.DBCommandOK(vpScenarioModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillVPScenarioWithoutRawResults(VPScenario vpScenario, VPScenarioModel vpScenarioModel, ContactOK contactOK)
        {
            vpScenario.DBCommand = (int)vpScenarioModel.DBCommand;
            vpScenario.InfrastructureTVItemID = vpScenarioModel.InfrastructureTVItemID;
            vpScenario.VPScenarioStatus = (int)vpScenarioModel.VPScenarioStatus;
            vpScenario.UseAsBestEstimate = (bool)vpScenarioModel.UseAsBestEstimate;
            vpScenario.EffluentFlow_m3_s = vpScenarioModel.EffluentFlow_m3_s;
            vpScenario.EffluentConcentration_MPN_100ml = vpScenarioModel.EffluentConcentration_MPN_100ml;
            vpScenario.FroudeNumber = vpScenarioModel.FroudeNumber;
            vpScenario.PortDiameter_m = vpScenarioModel.PortDiameter_m;
            vpScenario.PortDepth_m = vpScenarioModel.PortDepth_m;
            vpScenario.PortElevation_m = vpScenarioModel.PortElevation_m;
            vpScenario.VerticalAngle_deg = vpScenarioModel.VerticalAngle_deg;
            vpScenario.HorizontalAngle_deg = vpScenarioModel.HorizontalAngle_deg;
            vpScenario.NumberOfPorts = vpScenarioModel.NumberOfPorts;
            vpScenario.PortSpacing_m = vpScenarioModel.PortSpacing_m;
            vpScenario.AcuteMixZone_m = vpScenarioModel.AcuteMixZone_m;
            vpScenario.ChronicMixZone_m = vpScenarioModel.ChronicMixZone_m;
            vpScenario.EffluentSalinity_PSU = vpScenarioModel.EffluentSalinity_PSU;
            vpScenario.EffluentTemperature_C = vpScenarioModel.EffluentTemperature_C;
            vpScenario.EffluentVelocity_m_s = vpScenarioModel.EffluentVelocity_m_s;
            vpScenario.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                vpScenario.LastUpdateContactTVItemID = 2;
            }
            else
            {
                vpScenario.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public VPFullModel GetNextVPScenarioToRunDB()
        {
            VPFullModel vpFullModel = (from c in db.VPScenarios
                                       let vpScenarioName = (from cl in db.VPScenarioLanguages where cl.VPScenarioID == c.VPScenarioID select cl.VPScenarioName).FirstOrDefault()
                                       where c.VPScenarioStatus == (int)ScenarioStatusEnum.Changed
                                       orderby c.VPScenarioID
                                       select new VPFullModel
                                       {
                                           Error = "",
                                           VPScenarioID = c.VPScenarioID,
                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                           AcuteMixZone_m = c.AcuteMixZone_m,
                                           ChronicMixZone_m = c.ChronicMixZone_m,
                                           EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                                           EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                                           EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                                           EffluentTemperature_C = c.EffluentTemperature_C,
                                           EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                                           FroudeNumber = c.FroudeNumber,
                                           HorizontalAngle_deg = c.HorizontalAngle_deg,
                                           NumberOfPorts = c.NumberOfPorts,
                                           PortDepth_m = c.PortDepth_m,
                                           PortDiameter_m = c.PortDiameter_m,
                                           PortElevation_m = c.PortElevation_m,
                                           PortSpacing_m = c.PortSpacing_m,
                                           RawResults = c.RawResults,
                                           VPScenarioName = vpScenarioName,
                                           VPScenarioStatus = (ScenarioStatusEnum)c.VPScenarioStatus,
                                           InfrastructureTVItemID = c.InfrastructureTVItemID,
                                           UseAsBestEstimate = c.UseAsBestEstimate,
                                           VerticalAngle_deg = c.VerticalAngle_deg,
                                           LastUpdateDate_UTC = (DateTime)c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       }).FirstOrDefault<VPFullModel>();

            if (vpFullModel != null)
            {
                List<VPAmbientModel> vpAmbientList = (from c in db.VPAmbients
                                                      where c.VPScenarioID == vpFullModel.VPScenarioID
                                                      orderby c.Row
                                                      select new VPAmbientModel
                                                      {
                                                          Error = "",
                                                          VPAmbientID = c.VPAmbientID,
                                                          DBCommand = (DBCommandEnum)c.DBCommand,
                                                          VPScenarioID = vpFullModel.VPScenarioID,
                                                          AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                                          AmbientTemperature_C = c.AmbientTemperature_C,
                                                          BackgroundConcentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                                                          CurrentDirection_deg = c.CurrentDirection_deg,
                                                          CurrentSpeed_m_s = c.CurrentSpeed_m_s,
                                                          FarFieldCurrentDirection_deg = c.FarFieldCurrentDirection_deg,
                                                          FarFieldCurrentSpeed_m_s = c.FarFieldCurrentSpeed_m_s,
                                                          FarFieldDiffusionCoefficient = c.FarFieldDiffusionCoefficient,
                                                          MeasurementDepth_m = c.MeasurementDepth_m,
                                                          PollutantDecayRate_per_day = c.PollutantDecayRate_per_day,
                                                          Row = c.Row,
                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                      }).ToList<VPAmbientModel>();

                foreach (VPAmbientModel vpa in vpAmbientList)
                {
                    vpFullModel.AmbientList.Add(vpa);
                }

            }
            else
            {
                vpFullModel = new VPFullModel()
                {
                    Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario,
                    ServiceRes.VPScenarioStatus,
                    ScenarioStatusEnum.Changed)
                };
            }

            return vpFullModel;
        }
        public VPFullModel GetVPScenarioFullDB(int VPScenarioID)
        {
            if (VPScenarioID == 0)
                return new VPFullModel() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID) };

            VPFullModel vpFullModel = (from c in db.VPScenarios
                                       from cl in db.VPScenarioLanguages
                                       let infrastructureTVText = (from t in db.TVItemLanguages where t.TVItemID == c.InfrastructureTVItemID select t.TVText).FirstOrDefault()
                                       where c.VPScenarioID == cl.VPScenarioID
                                       && c.VPScenarioID == VPScenarioID
                                       && cl.Language == (int)LanguageRequest
                                       select new VPFullModel
                                       {
                                           Error = "",
                                           VPScenarioID = c.VPScenarioID,
                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                           InfrastructureTVItemID = c.InfrastructureTVItemID,
                                           InfrastructureTVText = infrastructureTVText,
                                           AcuteMixZone_m = c.AcuteMixZone_m,
                                           ChronicMixZone_m = c.ChronicMixZone_m,
                                           EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                                           EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                                           EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                                           EffluentTemperature_C = c.EffluentTemperature_C,
                                           EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                                           FroudeNumber = c.FroudeNumber,
                                           HorizontalAngle_deg = c.HorizontalAngle_deg,
                                           NumberOfPorts = c.NumberOfPorts,
                                           PortDepth_m = c.PortDepth_m,
                                           PortDiameter_m = c.PortDiameter_m,
                                           PortElevation_m = c.PortElevation_m,
                                           PortSpacing_m = c.PortSpacing_m,
                                           RawResults = c.RawResults,
                                           VPScenarioName = cl.VPScenarioName,
                                           VPScenarioStatus = (ScenarioStatusEnum)c.VPScenarioStatus,
                                           UseAsBestEstimate = c.UseAsBestEstimate,
                                           VerticalAngle_deg = c.VerticalAngle_deg,
                                           LastUpdateDate_UTC = (DateTime)c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       }).FirstOrDefault<VPFullModel>();

            if (vpFullModel != null)
            {
                List<VPAmbientModel> vpAmbientList = (from c in db.VPAmbients
                                                      where c.VPScenarioID == VPScenarioID
                                                      orderby c.Row
                                                      select new VPAmbientModel
                                                      {
                                                          Error = "",
                                                          VPAmbientID = c.VPAmbientID,
                                                          DBCommand = (DBCommandEnum)c.DBCommand,
                                                          VPScenarioID = c.VPScenarioID,
                                                          AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                                          AmbientTemperature_C = c.AmbientTemperature_C,
                                                          BackgroundConcentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                                                          CurrentDirection_deg = c.CurrentDirection_deg,
                                                          CurrentSpeed_m_s = c.CurrentSpeed_m_s,
                                                          FarFieldCurrentDirection_deg = c.FarFieldCurrentDirection_deg,
                                                          FarFieldCurrentSpeed_m_s = c.FarFieldCurrentSpeed_m_s,
                                                          FarFieldDiffusionCoefficient = c.FarFieldDiffusionCoefficient,
                                                          MeasurementDepth_m = c.MeasurementDepth_m,
                                                          PollutantDecayRate_per_day = c.PollutantDecayRate_per_day,
                                                          Row = c.Row,
                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                      }).ToList<VPAmbientModel>();

                foreach (VPAmbientModel vpa in vpAmbientList)
                {
                    vpFullModel.AmbientList.Add(vpa);
                }

                List<VPResultModel> vpResultList = (from c in db.VPResults
                                                    where c.VPScenarioID == VPScenarioID
                                                    orderby c.Ordinal
                                                    select new VPResultModel
                                                    {
                                                        Error = "",
                                                        VPResultID = c.VPResultID,
                                                        DBCommand = (DBCommandEnum)c.DBCommand,
                                                        VPScenarioID = c.VPScenarioID,
                                                        Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                                        Dilution = c.Dilution,
                                                        DispersionDistance_m = c.DispersionDistance_m,
                                                        FarFieldWidth_m = c.FarFieldWidth_m,
                                                        Ordinal = c.Ordinal,
                                                        TravelTime_hour = c.TravelTime_hour,
                                                    }).ToList<VPResultModel>();

                foreach (VPResultModel vpr in vpResultList)
                {
                    vpFullModel.ResultList.Add(vpr);
                }
            }

            return vpFullModel;
        }
        public int GetVPScenarioModelCountDB()
        {
            int VPScenarioModelCount = (from c in db.VPScenarios
                                        select c).Count();

            return VPScenarioModelCount;
        }
        public List<VPScenarioModel> GetVPScenarioModelListWithInfrastructureTVItemIDDB(int InfrastructureTVItemID)
        {
            List<VPScenarioModel> VPScenarioModelList = (from c in db.VPScenarios
                                                         let vpScenarioName = (from vpl in db.VPScenarioLanguages where vpl.Language == (int)LanguageRequest && vpl.VPScenarioID == c.VPScenarioID select vpl.VPScenarioName).FirstOrDefault<string>()
                                                         let infraName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         where c.InfrastructureTVItemID == InfrastructureTVItemID
                                                         orderby vpScenarioName
                                                         select new VPScenarioModel
                                                         {
                                                             Error = "",
                                                             VPScenarioID = c.VPScenarioID,
                                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                                             VPScenarioName = vpScenarioName,
                                                             InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                             InfrastructureTVText = infraName,
                                                             VPScenarioStatus = (ScenarioStatusEnum)c.VPScenarioStatus,
                                                             UseAsBestEstimate = c.UseAsBestEstimate,
                                                             EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                                                             EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                                                             FroudeNumber = c.FroudeNumber,
                                                             PortDiameter_m = c.PortDiameter_m,
                                                             PortDepth_m = c.PortDepth_m,
                                                             PortElevation_m = c.PortElevation_m,
                                                             VerticalAngle_deg = c.VerticalAngle_deg,
                                                             HorizontalAngle_deg = c.HorizontalAngle_deg,
                                                             NumberOfPorts = c.NumberOfPorts,
                                                             PortSpacing_m = c.PortSpacing_m,
                                                             AcuteMixZone_m = c.AcuteMixZone_m,
                                                             ChronicMixZone_m = c.ChronicMixZone_m,
                                                             EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                                                             EffluentTemperature_C = c.EffluentTemperature_C,
                                                             EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                                                             //RawResults = c.RawResults,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<VPScenarioModel>();

            return VPScenarioModelList;
        }
        public VPScenarioModel GetVPScenarioModelWithVPScenarioIDDB(int VPScenarioID)
        {
            VPScenarioModel vpScenarioModel = (from c in db.VPScenarios
                                               let vpScenarioName = (from vpl in db.VPScenarioLanguages where vpl.Language == (int)LanguageRequest && vpl.VPScenarioID == c.VPScenarioID select vpl.VPScenarioName).FirstOrDefault<string>()
                                               let infraName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                               where c.VPScenarioID == VPScenarioID
                                               select new VPScenarioModel
                                               {
                                                   Error = "",
                                                   VPScenarioID = c.VPScenarioID,
                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                   VPScenarioName = vpScenarioName,
                                                   InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                   InfrastructureTVText = infraName,
                                                   VPScenarioStatus = (ScenarioStatusEnum)c.VPScenarioStatus,
                                                   UseAsBestEstimate = c.UseAsBestEstimate,
                                                   EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                                                   EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                                                   FroudeNumber = c.FroudeNumber,
                                                   PortDiameter_m = c.PortDiameter_m,
                                                   PortDepth_m = c.PortDepth_m,
                                                   PortElevation_m = c.PortElevation_m,
                                                   VerticalAngle_deg = c.VerticalAngle_deg,
                                                   HorizontalAngle_deg = c.HorizontalAngle_deg,
                                                   NumberOfPorts = c.NumberOfPorts,
                                                   PortSpacing_m = c.PortSpacing_m,
                                                   AcuteMixZone_m = c.AcuteMixZone_m,
                                                   ChronicMixZone_m = c.ChronicMixZone_m,
                                                   EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                                                   EffluentTemperature_C = c.EffluentTemperature_C,
                                                   EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                                                   //RawResults = c.RawResults,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).FirstOrDefault<VPScenarioModel>();


            if (vpScenarioModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.VPScenarioID, VPScenarioID));

            return vpScenarioModel;
        }
        public VPScenarioModel GetVPScenarioModelWithInfrastructureTVItemIDAndVPScenarioNameDB(int InfrastructureTVItemID, string VPScenarioName)
        {
            VPScenarioModel vpScenarioModel = (from c in db.VPScenarios
                                               from cl in db.VPScenarioLanguages
                                               let vpScenarioName = (from vpl in db.VPScenarioLanguages where vpl.Language == (int)LanguageRequest && vpl.VPScenarioID == c.VPScenarioID select vpl.VPScenarioName).FirstOrDefault<string>()
                                               let infraName = (from cll in db.TVItemLanguages where cll.Language == (int)LanguageRequest && cll.TVItemID == c.InfrastructureTVItemID select cll.TVText).FirstOrDefault<string>()
                                               where c.VPScenarioID == cl.VPScenarioID
                                               && c.InfrastructureTVItemID == InfrastructureTVItemID
                                               && cl.VPScenarioName == VPScenarioName
                                               select new VPScenarioModel
                                               {
                                                   Error = "",
                                                   VPScenarioID = c.VPScenarioID,
                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                   VPScenarioName = vpScenarioName,
                                                   InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                   InfrastructureTVText = infraName,
                                                   VPScenarioStatus = (ScenarioStatusEnum)c.VPScenarioStatus,
                                                   UseAsBestEstimate = c.UseAsBestEstimate,
                                                   EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                                                   EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                                                   FroudeNumber = c.FroudeNumber,
                                                   PortDiameter_m = c.PortDiameter_m,
                                                   PortDepth_m = c.PortDepth_m,
                                                   PortElevation_m = c.PortElevation_m,
                                                   VerticalAngle_deg = c.VerticalAngle_deg,
                                                   HorizontalAngle_deg = c.HorizontalAngle_deg,
                                                   NumberOfPorts = c.NumberOfPorts,
                                                   PortSpacing_m = c.PortSpacing_m,
                                                   AcuteMixZone_m = c.AcuteMixZone_m,
                                                   ChronicMixZone_m = c.ChronicMixZone_m,
                                                   EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                                                   EffluentTemperature_C = c.EffluentTemperature_C,
                                                   EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                                                   //RawResults = c.RawResults,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).FirstOrDefault<VPScenarioModel>();


            if (vpScenarioModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.InfrastructureTVItemID + "," + ServiceRes.VPScenarioName, InfrastructureTVItemID + "," + VPScenarioName));

            return vpScenarioModel;
        }
        public VPScenario GetVPScenarioWithVPScenarioIDDB(int VPScenarioID)
        {
            VPScenario vpScenario = (from c in db.VPScenarios
                                     where c.VPScenarioID == VPScenarioID
                                     select c).FirstOrDefault<VPScenario>();

            return vpScenario;
        }
        public VPScenario GetVPScenarioWithInfrastructureTVItemIDAndVPScenarioNameDB(int InfrastructureTVItemID, string VPScenarioName)
        {
            VPScenario vpScenario = (from c in db.VPScenarios
                                     from cl in db.VPScenarioLanguages
                                     where c.VPScenarioID == cl.VPScenarioID
                                     && c.InfrastructureTVItemID == InfrastructureTVItemID
                                     && cl.VPScenarioName == VPScenarioName
                                     select c).FirstOrDefault<VPScenario>();

            return vpScenario;
        }

        // Helper
        public VPScenarioModel ReturnError(string Error)
        {
            return new VPScenarioModel() { Error = Error };
        }

        // Post Normal
        public VPScenarioModel PostAddVPScenarioDB(VPScenarioModel vpScenarioModel)
        {
            string retStr = VPScenarioModelOK(vpScenarioModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelInfrastructure = _TVItemService.GetTVItemModelWithTVItemIDDB(vpScenarioModel.InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                return ReturnError(tvItemModelInfrastructure.Error);

            VPScenario vpScenarioExist = GetVPScenarioWithInfrastructureTVItemIDAndVPScenarioNameDB(vpScenarioModel.InfrastructureTVItemID, vpScenarioModel.VPScenarioName);
            if (vpScenarioExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPScenario));

            VPScenario vpScenarioNew = new VPScenario();
            retStr = FillVPScenarioWithoutRawResults(vpScenarioNew, vpScenarioModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPScenarios.Add(vpScenarioNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarios", vpScenarioNew.VPScenarioID, LogCommandEnum.Add, vpScenarioNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    VPScenarioLanguageModel vpScenarioLanguageModel = new VPScenarioLanguageModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        VPScenarioID = vpScenarioNew.VPScenarioID,
                        Language = Lang,
                        VPScenarioName = vpScenarioModel.VPScenarioName,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = _VPScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModel);
                    if (!string.IsNullOrEmpty(vpScenarioLanguageModelRet.Error))
                        return ReturnError(vpScenarioLanguageModelRet.Error);
                }


                ts.Complete();
            }
            return GetVPScenarioModelWithVPScenarioIDDB(vpScenarioNew.VPScenarioID);
        }
        public VPScenarioModel PostDeleteVPScenarioDB(int VPScenarioID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPScenario vpScenarioToDelete = GetVPScenarioWithVPScenarioIDDB(VPScenarioID);
            if (vpScenarioToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPScenario));

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPScenarios.Remove(vpScenarioToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarios", vpScenarioToDelete.VPScenarioID, LogCommandEnum.Delete, vpScenarioToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public VPScenarioModel PostUpdateVPScenarioWithoutRawResultsDB(VPScenarioModel vpScenarioModel)
        {
            string retStr = VPScenarioModelOK(vpScenarioModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPScenario vpScenarioToUpdate = GetVPScenarioWithVPScenarioIDDB(vpScenarioModel.VPScenarioID);
            if (vpScenarioToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPScenario));

            retStr = FillVPScenarioWithoutRawResults(vpScenarioToUpdate, vpScenarioModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarios", vpScenarioToUpdate.VPScenarioID, LogCommandEnum.Change, vpScenarioToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        VPScenarioLanguageModel vpScenarioLanguageModel = new VPScenarioLanguageModel()
                        {
                            DBCommand = DBCommandEnum.Original,
                            VPScenarioID = vpScenarioModel.VPScenarioID,
                            Language = Lang,
                            VPScenarioName = vpScenarioModel.VPScenarioName,
                            TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = _VPScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModel);
                        if (!string.IsNullOrEmpty(vpScenarioLanguageModelRet.Error))
                            return ReturnError(vpScenarioLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return GetVPScenarioModelWithVPScenarioIDDB(vpScenarioToUpdate.VPScenarioID);
        }
        public VPScenarioModel PostUpdateVPScenarioRawResultsDB(int VPScenarioID, string RawResults)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPScenario vpScenarioToUpdate = GetVPScenarioWithVPScenarioIDDB(VPScenarioID);
            if (vpScenarioToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPScenario));

            vpScenarioToUpdate.RawResults = RawResults;

            using (TransactionScope ts = new TransactionScope())
            {
                string retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarios", vpScenarioToUpdate.VPScenarioID, LogCommandEnum.Change, vpScenarioToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPScenarioModelWithVPScenarioIDDB(vpScenarioToUpdate.VPScenarioID);
        }

        // Post Command
        public VPScenarioModel PostCopyVPScenarioDB(int VPScenarioID)
        {
            VPScenarioModel vpScenarioModel = GetVPScenarioModelWithVPScenarioIDDB(VPScenarioID);
            if (!string.IsNullOrWhiteSpace(vpScenarioModel.Error))
                return ReturnError(vpScenarioModel.Error);

            VPScenarioModel vpScenarioModelNew = new VPScenarioModel();
            vpScenarioModelNew.DBCommand = vpScenarioModel.DBCommand;
            vpScenarioModelNew.AcuteMixZone_m = vpScenarioModel.AcuteMixZone_m;
            vpScenarioModelNew.ChronicMixZone_m = vpScenarioModel.ChronicMixZone_m;
            vpScenarioModelNew.EffluentConcentration_MPN_100ml = vpScenarioModel.EffluentConcentration_MPN_100ml;
            vpScenarioModelNew.EffluentFlow_m3_s = vpScenarioModel.EffluentFlow_m3_s;
            vpScenarioModelNew.EffluentSalinity_PSU = vpScenarioModel.EffluentSalinity_PSU;
            vpScenarioModelNew.EffluentTemperature_C = vpScenarioModel.EffluentTemperature_C;
            vpScenarioModelNew.FroudeNumber = vpScenarioModel.FroudeNumber;
            vpScenarioModelNew.HorizontalAngle_deg = vpScenarioModel.HorizontalAngle_deg;
            vpScenarioModelNew.VPScenarioStatus = ScenarioStatusEnum.Copied;
            vpScenarioModelNew.NumberOfPorts = vpScenarioModel.NumberOfPorts;
            vpScenarioModelNew.PortDepth_m = vpScenarioModel.PortDepth_m;
            vpScenarioModelNew.PortDiameter_m = vpScenarioModel.PortDiameter_m;
            vpScenarioModelNew.PortElevation_m = vpScenarioModel.PortElevation_m;
            vpScenarioModelNew.PortSpacing_m = vpScenarioModel.PortSpacing_m;
            vpScenarioModelNew.InfrastructureTVItemID = vpScenarioModel.InfrastructureTVItemID;
            vpScenarioModelNew.UseAsBestEstimate = vpScenarioModel.UseAsBestEstimate;
            vpScenarioModelNew.VerticalAngle_deg = vpScenarioModel.VerticalAngle_deg;
            vpScenarioModelNew.VPScenarioName = "__ " + ServiceRes.CopyOf + " "
                + _VPScenarioLanguageService.GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(VPScenarioID, LanguageRequest).VPScenarioName;

            VPScenarioModel vpScenarioModelRet = PostAddVPScenarioDB(vpScenarioModelNew);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
                return ReturnError(vpScenarioModelRet.Error);

            List<VPAmbientModel> vpAmbientModelList = _VPAmbientService.GetVPAmbientModelListWithVPScenarioIDDB(VPScenarioID);
            if (vpAmbientModelList.Count == 1 && !string.IsNullOrWhiteSpace(vpAmbientModelList[0].Error))
                return ReturnError(vpAmbientModelList[0].Error);

            foreach (VPAmbientModel vpAmbientModel in vpAmbientModelList)
            {
                VPAmbientModel vpAmbientModelNew = new VPAmbientModel();
                vpAmbientModelNew.DBCommand = vpScenarioModelRet.DBCommand;
                vpAmbientModelNew.VPScenarioID = vpScenarioModelRet.VPScenarioID;
                vpAmbientModelNew.AmbientSalinity_PSU = vpAmbientModel.AmbientSalinity_PSU;
                vpAmbientModelNew.AmbientTemperature_C = vpAmbientModel.AmbientTemperature_C;
                vpAmbientModelNew.BackgroundConcentration_MPN_100ml = vpAmbientModel.BackgroundConcentration_MPN_100ml;
                vpAmbientModelNew.CurrentDirection_deg = vpAmbientModel.CurrentDirection_deg;
                vpAmbientModelNew.CurrentSpeed_m_s = vpAmbientModel.CurrentSpeed_m_s;
                vpAmbientModelNew.FarFieldCurrentDirection_deg = vpAmbientModel.FarFieldCurrentDirection_deg;
                vpAmbientModelNew.FarFieldCurrentSpeed_m_s = vpAmbientModel.FarFieldCurrentSpeed_m_s;
                vpAmbientModelNew.FarFieldDiffusionCoefficient = vpAmbientModel.FarFieldDiffusionCoefficient;
                vpAmbientModelNew.MeasurementDepth_m = vpAmbientModel.MeasurementDepth_m;
                vpAmbientModelNew.PollutantDecayRate_per_day = vpAmbientModel.PollutantDecayRate_per_day;
                vpAmbientModelNew.Row = vpAmbientModel.Row;

                VPAmbientModel vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
                if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                    return ReturnError(vpAmbientModelRet.Error);
            }

            return vpScenarioModelRet;
        }
        public VPScenarioModel PostCreateNewVPScenarioDB(int InfrastructureTVItemID)
        {
            if (InfrastructureTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID));

            VPScenarioModel vpScenarioModelNew = new VPScenarioModel();
            vpScenarioModelNew.DBCommand = DBCommandEnum.Original;
            vpScenarioModelNew.AcuteMixZone_m = 50;
            vpScenarioModelNew.ChronicMixZone_m = 40000;
            vpScenarioModelNew.EffluentConcentration_MPN_100ml = 3200000;
            vpScenarioModelNew.EffluentFlow_m3_s = 0.111111;
            vpScenarioModelNew.EffluentSalinity_PSU = 0;
            vpScenarioModelNew.EffluentTemperature_C = 15;
            vpScenarioModelNew.FroudeNumber = 0;
            vpScenarioModelNew.HorizontalAngle_deg = 90;
            vpScenarioModelNew.VPScenarioStatus = ScenarioStatusEnum.Copied;
            vpScenarioModelNew.NumberOfPorts = 1;
            vpScenarioModelNew.PortDepth_m = 2;
            vpScenarioModelNew.PortDiameter_m = 0.25;
            vpScenarioModelNew.PortElevation_m = 0.125;
            vpScenarioModelNew.PortSpacing_m = 1000;
            vpScenarioModelNew.InfrastructureTVItemID = InfrastructureTVItemID;
            vpScenarioModelNew.UseAsBestEstimate = false;
            vpScenarioModelNew.VerticalAngle_deg = 0;
            vpScenarioModelNew.VPScenarioName = "__ " + new Random().Next(1000, 20000) + ServiceRes.NewScenario;

            VPScenarioModel vpScenarioModelRet = PostAddVPScenarioDB(vpScenarioModelNew);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
                return ReturnError(vpScenarioModelRet.Error);

            vpScenarioModelRet.VPScenarioName = "__ " + vpScenarioModelRet.VPScenarioID + " " + ServiceRes.NewScenario;

            vpScenarioModelRet = PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModelRet);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
                return ReturnError(vpScenarioModelRet.Error);

            VPAmbientModel vpAmbientModelNew = new VPAmbientModel();
            vpAmbientModelNew.DBCommand = DBCommandEnum.Original;
            vpAmbientModelNew.AmbientSalinity_PSU = 28;
            vpAmbientModelNew.AmbientTemperature_C = 10;
            vpAmbientModelNew.BackgroundConcentration_MPN_100ml = 5;
            vpAmbientModelNew.CurrentDirection_deg = 90;
            vpAmbientModelNew.CurrentSpeed_m_s = 0.0;
            vpAmbientModelNew.FarFieldCurrentDirection_deg = 90;
            vpAmbientModelNew.FarFieldCurrentSpeed_m_s = 0.1;
            vpAmbientModelNew.FarFieldDiffusionCoefficient = 0.0003;
            vpAmbientModelNew.MeasurementDepth_m = 0.0;
            vpAmbientModelNew.PollutantDecayRate_per_day = 4.6821;
            vpAmbientModelNew.Row = 1;
            vpAmbientModelNew.VPScenarioID = vpScenarioModelRet.VPScenarioID;

            VPAmbientModel vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.AmbientSalinity_PSU = null;
            vpAmbientModelNew.DBCommand = DBCommandEnum.Original;
            vpAmbientModelNew.AmbientTemperature_C = null;
            vpAmbientModelNew.BackgroundConcentration_MPN_100ml = null;
            vpAmbientModelNew.CurrentDirection_deg = null;
            vpAmbientModelNew.CurrentSpeed_m_s = null;
            vpAmbientModelNew.FarFieldCurrentDirection_deg = null;
            vpAmbientModelNew.FarFieldCurrentSpeed_m_s = null;
            vpAmbientModelNew.FarFieldDiffusionCoefficient = null;
            vpAmbientModelNew.MeasurementDepth_m = 2;
            vpAmbientModelNew.PollutantDecayRate_per_day = null;
            vpAmbientModelNew.Row = 2;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.AmbientSalinity_PSU = null;
            vpAmbientModelNew.DBCommand = DBCommandEnum.Original;
            vpAmbientModelNew.AmbientTemperature_C = null;
            vpAmbientModelNew.BackgroundConcentration_MPN_100ml = null;
            vpAmbientModelNew.CurrentDirection_deg = null;
            vpAmbientModelNew.CurrentSpeed_m_s = null;
            vpAmbientModelNew.FarFieldCurrentDirection_deg = null;
            vpAmbientModelNew.FarFieldCurrentSpeed_m_s = null;
            vpAmbientModelNew.FarFieldDiffusionCoefficient = null;
            vpAmbientModelNew.MeasurementDepth_m = null;
            vpAmbientModelNew.PollutantDecayRate_per_day = null;
            vpAmbientModelNew.Row = 3;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.Row = 4;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.Row = 5;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.Row = 6;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.Row = 7;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);

            vpAmbientModelNew.Row = 8;

            vpAmbientModelRet = _VPAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                return ReturnError(vpAmbientModelRet.Error);


            return vpScenarioModelRet;
        }
        public VPScenarioModel PostSaveResultsInDB(int VPScenarioID, string RawResults)
        {
            if (LanguageRequest == LanguageEnum.fr)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-CA");
            }

            StringBuilder sb = new StringBuilder(RawResults);

            if (sb.Length != 0)
            {
                VPScenarioModel vpScenarioModel = GetVPScenarioModelWithVPScenarioIDDB(VPScenarioID);
                if (!string.IsNullOrWhiteSpace(vpScenarioModel.Error))
                    return ReturnError(vpScenarioModel.Error);


                if (RawResults.StartsWith("Error"))
                {
                    vpScenarioModel.VPScenarioStatus = ScenarioStatusEnum.Error;
                    //vpScenarioModel.RawResults = RawResults;

                    VPScenarioModel vpScenarioModelRet2 = PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModel);
                    if (!string.IsNullOrWhiteSpace(vpScenarioModelRet2.Error))
                        return ReturnError(vpScenarioModelRet2.Error);

                    vpScenarioModel = PostUpdateVPScenarioRawResultsDB(VPScenarioID, RawResults);
                    if (!string.IsNullOrWhiteSpace(vpScenarioModel.Error))
                        return ReturnError(vpScenarioModel.Error);

                    return ReturnError("");
                }

                List<VPAmbientModel> vpAmbientModelList = _VPAmbientService.GetVPAmbientModelListWithVPScenarioIDDB(VPScenarioID);
                if (vpAmbientModelList.Count() != 8)
                    return ReturnError(ServiceRes.AmbientCountNotEqual8);

                //vpAmbientModelList = new List<VPAmbientModel>();
                //foreach (VPAmbientModel vpAmbientModel in vpAmbientModelList)
                //{
                //    vpAmbientModelList.Add(vpAmbientModel);
                //}

                double? oldMeasurementDepth = vpAmbientModelList[0].MeasurementDepth_m;
                double? oldCurrentSpeed = vpAmbientModelList[0].CurrentSpeed_m_s;
                double? oldCurrentDirection = vpAmbientModelList[0].CurrentDirection_deg;
                double? oldAmbientSalinity = vpAmbientModelList[0].AmbientSalinity_PSU;
                double? oldAmbientTemperature = vpAmbientModelList[0].AmbientTemperature_C;
                int? oldBackgroundConcentration_MPN_100ml = vpAmbientModelList[0].BackgroundConcentration_MPN_100ml;
                double? oldPollutantDecayRate = vpAmbientModelList[0].PollutantDecayRate_per_day;
                double? oldFarFieldCurrentSpeed = vpAmbientModelList[0].FarFieldCurrentSpeed_m_s;
                double? oldFarFieldCurrentDirection = vpAmbientModelList[0].FarFieldCurrentDirection_deg;
                double? oldFarFieldDiffusionCoefficient = vpAmbientModelList[0].FarFieldDiffusionCoefficient;

                foreach (VPAmbientModel vpAmbientModel in vpAmbientModelList)
                {
                    if (vpAmbientModel.MeasurementDepth_m == null)
                    {
                        vpAmbientModel.MeasurementDepth_m = oldMeasurementDepth;
                    }
                    oldMeasurementDepth = vpAmbientModel.MeasurementDepth_m;

                    if (vpAmbientModel.CurrentSpeed_m_s == null)
                    {
                        vpAmbientModel.CurrentSpeed_m_s = oldCurrentSpeed;
                    }
                    oldCurrentSpeed = vpAmbientModel.CurrentSpeed_m_s;

                    if (vpAmbientModel.CurrentDirection_deg == null)
                    {
                        vpAmbientModel.CurrentDirection_deg = oldCurrentDirection;
                    }
                    oldCurrentDirection = vpAmbientModel.CurrentDirection_deg;

                    if (vpAmbientModel.AmbientSalinity_PSU == null)
                    {
                        vpAmbientModel.AmbientSalinity_PSU = oldAmbientSalinity;
                    }
                    oldAmbientSalinity = vpAmbientModel.AmbientSalinity_PSU;

                    if (vpAmbientModel.AmbientTemperature_C == null)
                    {
                        vpAmbientModel.AmbientTemperature_C = oldAmbientTemperature;
                    }
                    oldAmbientTemperature = vpAmbientModel.AmbientTemperature_C;

                    if (vpAmbientModel.BackgroundConcentration_MPN_100ml == null)
                    {
                        vpAmbientModel.BackgroundConcentration_MPN_100ml = oldBackgroundConcentration_MPN_100ml;
                    }
                    oldBackgroundConcentration_MPN_100ml = vpAmbientModel.BackgroundConcentration_MPN_100ml;

                    if (vpAmbientModel.PollutantDecayRate_per_day == null)
                    {
                        vpAmbientModel.PollutantDecayRate_per_day = oldPollutantDecayRate;
                    }
                    oldPollutantDecayRate = vpAmbientModel.PollutantDecayRate_per_day;

                    if (vpAmbientModel.FarFieldCurrentSpeed_m_s == null)
                    {
                        vpAmbientModel.FarFieldCurrentSpeed_m_s = oldFarFieldCurrentSpeed;
                    }
                    oldFarFieldCurrentSpeed = vpAmbientModel.FarFieldCurrentSpeed_m_s;

                    if (vpAmbientModel.FarFieldCurrentDirection_deg == null)
                    {
                        vpAmbientModel.FarFieldCurrentDirection_deg = oldFarFieldCurrentDirection;
                    }
                    oldFarFieldCurrentDirection = vpAmbientModel.FarFieldCurrentDirection_deg;

                    if (vpAmbientModel.FarFieldDiffusionCoefficient == null)
                    {
                        vpAmbientModel.FarFieldDiffusionCoefficient = oldFarFieldDiffusionCoefficient;
                    }
                    oldFarFieldDiffusionCoefficient = vpAmbientModel.FarFieldDiffusionCoefficient;
                }


                string ResText = RawResults;
                TextReader tr = new StringReader(RawResults);

                int FirstFound = ResText.IndexOf(" UM3.");
                if (FirstFound < 0)
                    return ReturnError(ServiceRes.CouldNotParseVisualPlumesResultFile + " " + string.Format(ServiceRes.CouldNotFind_, "UM3"));

                int LastFound = ResText.LastIndexOf(" UM3.");

                if (FirstFound != LastFound)
                    return ReturnError(ServiceRes.CouldNotParseVisualPlumesResultFile + " " + string.Format(ServiceRes.CouldNotFind_, "UM3"));

                bool StartReadingValues = false;
                bool IsFirstPart = false;
                bool GotDecayAlready = false;
                List<VPResValues> listOfResVal = new List<VPResValues>();


                string TempTxt = tr.ReadLine();
                while (TempTxt != null)
                {
                    TempTxt = tr.ReadLine();
                    if (TempTxt == null)
                    {
                        continue;
                    }

                    if (TempTxt == "")
                    {
                        TempTxt = " ";
                        continue;
                    }

                    if (TempTxt.Length < 6)
                        continue;

                    if (TempTxt.Substring(0, 6) == "Ambien")
                    {
                        TempTxt = tr.ReadLine();
                        TempTxt = tr.ReadLine();
                        for (int i = 0; i < 8; i++)
                        {
                            TempTxt = tr.ReadLine();

                            if (Math.Abs((double)vpAmbientModelList[i].MeasurementDepth_m - double.Parse(TempTxt.Substring(0, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.MeasurementDepth) + " [" + vpAmbientModelList[0].MeasurementDepth_m + "] [" + double.Parse(TempTxt.Substring(0, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].CurrentSpeed_m_s - double.Parse(TempTxt.Substring(10, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.CurrentSpeed) + " [" + vpAmbientModelList[0].CurrentSpeed_m_s + "] [" + double.Parse(TempTxt.Substring(10, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].CurrentDirection_deg - double.Parse(TempTxt.Substring(20, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.CurrentDirection) + " [" + vpAmbientModelList[0].CurrentDirection_deg + "] [" + double.Parse(TempTxt.Substring(20, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].AmbientSalinity_PSU - double.Parse(TempTxt.Substring(30, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.AmbientSalinity) + " [" + vpAmbientModelList[0].AmbientSalinity_PSU + "] [" + double.Parse(TempTxt.Substring(30, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].AmbientTemperature_C - double.Parse(TempTxt.Substring(40, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.AmbientTemperature) + " [" + vpAmbientModelList[0].AmbientTemperature_C + "] [" + double.Parse(TempTxt.Substring(40, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].BackgroundConcentration_MPN_100ml - double.Parse(TempTxt.Substring(50, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.BackgroundConcentration_MPN_100ml) + " [" + vpAmbientModelList[0].BackgroundConcentration_MPN_100ml + "] [" + double.Parse(TempTxt.Substring(50, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].PollutantDecayRate_per_day - double.Parse(TempTxt.Substring(60, 10)) * 3600 * 24) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PollutantDecayRate) + " [" + vpAmbientModelList[0].PollutantDecayRate_per_day + "] [" + double.Parse(TempTxt.Substring(60, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].FarFieldCurrentSpeed_m_s - double.Parse(TempTxt.Substring(70, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.FarFieldCurrentSpeed) + " [" + vpAmbientModelList[0].FarFieldCurrentSpeed_m_s + "] [" + double.Parse(TempTxt.Substring(70, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].FarFieldCurrentDirection_deg - double.Parse(TempTxt.Substring(80, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.FarFieldCurrentDirection) + " [" + vpAmbientModelList[0].FarFieldCurrentDirection_deg + "] [" + double.Parse(TempTxt.Substring(80, 10)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpAmbientModelList[i].FarFieldDiffusionCoefficient - double.Parse(TempTxt.Substring(90, 10))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.FarFieldDiffusionCoefficient) + " [" + vpAmbientModelList[0].FarFieldDiffusionCoefficient + "] [" + double.Parse(TempTxt.Substring(90, 10)) + "] \r\n");
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(TempTxt))
                        continue;

                    if (TempTxt.Substring(0, 8) == "Diffuser")
                    {
                        TempTxt = tr.ReadLine();
                        if (TempTxt.Substring(0, 72) == "   P-dia  P-elev V-angle H-angle   Ports AcuteMZ ChrncMZ P-depth Ttl-flo")
                        {
                            TempTxt = tr.ReadLine();
                            TempTxt = tr.ReadLine();
                            if (Math.Abs((double)vpScenarioModel.PortDiameter_m - double.Parse(TempTxt.Substring(0, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortDiameter) + " [" + vpScenarioModel.PortDiameter_m + "] [" + double.Parse(TempTxt.Substring(0, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.PortElevation_m - double.Parse(TempTxt.Substring(8, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortElevation) + " [" + vpScenarioModel.PortElevation_m + "] [" + double.Parse(TempTxt.Substring(8, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.VerticalAngle_deg - double.Parse(TempTxt.Substring(16, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.VerticalAngle) + " [" + vpScenarioModel.VerticalAngle_deg + "] [" + double.Parse(TempTxt.Substring(16, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.HorizontalAngle_deg - double.Parse(TempTxt.Substring(24, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.HorizontalAngle) + " [" + vpScenarioModel.HorizontalAngle_deg + "] [" + double.Parse(TempTxt.Substring(24, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.NumberOfPorts - double.Parse(TempTxt.Substring(32, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.NumberOfPorts) + " [" + vpScenarioModel.NumberOfPorts + "] [" + double.Parse(TempTxt.Substring(32, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.AcuteMixZone_m - double.Parse(TempTxt.Substring(40, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.AcuteMixZone) + " [" + vpScenarioModel.AcuteMixZone_m + "] [" + double.Parse(TempTxt.Substring(40, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.ChronicMixZone_m - double.Parse(TempTxt.Substring(48, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.ChronicMixZone) + " [" + vpScenarioModel.ChronicMixZone_m + "] [" + double.Parse(TempTxt.Substring(48, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.PortDepth_m - double.Parse(TempTxt.Substring(56, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortDepth) + "h [" + vpScenarioModel.PortDepth_m + "] [" + double.Parse(TempTxt.Substring(56, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentFlow_m3_s - double.Parse(TempTxt.Substring(64, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentFlow) + " [" + vpScenarioModel.EffluentFlow_m3_s + "] [" + double.Parse(TempTxt.Substring(64, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentSalinity_PSU - double.Parse(TempTxt.Substring(72, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentSalinity) + " [" + vpScenarioModel.EffluentSalinity_PSU + "] [" + double.Parse(TempTxt.Substring(72, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentTemperature_C - double.Parse(TempTxt.Substring(80, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentTemperature) + " [" + vpScenarioModel.EffluentTemperature_C + "] [" + double.Parse(TempTxt.Substring(80, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentConcentration_MPN_100ml - double.Parse(TempTxt.Substring(88, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentConcentration_MPN_100ml) + " [" + vpScenarioModel.EffluentConcentration_MPN_100ml + "] [" + double.Parse(TempTxt.Substring(88, 8)) + "] \r\n");
                            }
                        }
                        else if (TempTxt.Substring(0, 72) == "   P-dia  P-elev V-angle H-angle   Ports Spacing AcuteMZ ChrncMZ P-depth")
                        {
                            TempTxt = tr.ReadLine();
                            TempTxt = tr.ReadLine();
                            if (Math.Abs((double)vpScenarioModel.PortDiameter_m - double.Parse(TempTxt.Substring(0, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortDiameter) + " [" + vpScenarioModel.PortDiameter_m + "] [" + double.Parse(TempTxt.Substring(0, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.PortElevation_m - double.Parse(TempTxt.Substring(8, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortElevation) + " [" + vpScenarioModel.PortElevation_m + "] [" + double.Parse(TempTxt.Substring(8, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.VerticalAngle_deg - double.Parse(TempTxt.Substring(16, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.VerticalAngle) + " [" + vpScenarioModel.VerticalAngle_deg + "] [" + double.Parse(TempTxt.Substring(16, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.HorizontalAngle_deg - double.Parse(TempTxt.Substring(24, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.HorizontalAngle) + " [" + vpScenarioModel.HorizontalAngle_deg + "] [" + double.Parse(TempTxt.Substring(24, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.NumberOfPorts - double.Parse(TempTxt.Substring(32, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.NumberOfPorts) + " [" + vpScenarioModel.NumberOfPorts + "] [" + double.Parse(TempTxt.Substring(32, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.PortSpacing_m - double.Parse(TempTxt.Substring(40, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortSpacing) + " [" + vpScenarioModel.PortSpacing_m + "] [" + double.Parse(TempTxt.Substring(40, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.AcuteMixZone_m - double.Parse(TempTxt.Substring(48, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.AcuteMixZone) + " [" + vpScenarioModel.AcuteMixZone_m + "] [" + double.Parse(TempTxt.Substring(48, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.ChronicMixZone_m - double.Parse(TempTxt.Substring(56, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.ChronicMixZone) + "e [" + vpScenarioModel.ChronicMixZone_m + "] [" + double.Parse(TempTxt.Substring(56, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.PortDepth_m - double.Parse(TempTxt.Substring(64, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.PortDepth) + " [" + vpScenarioModel.PortDepth_m + "] [" + double.Parse(TempTxt.Substring(64, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentFlow_m3_s - double.Parse(TempTxt.Substring(72, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentFlow) + " [" + vpScenarioModel.EffluentFlow_m3_s + "] [" + double.Parse(TempTxt.Substring(72, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentSalinity_PSU - double.Parse(TempTxt.Substring(80, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentSalinity) + " [" + vpScenarioModel.EffluentSalinity_PSU + "] [" + double.Parse(TempTxt.Substring(80, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentTemperature_C - double.Parse(TempTxt.Substring(88, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentTemperature) + " [" + vpScenarioModel.EffluentTemperature_C + "] [" + double.Parse(TempTxt.Substring(88, 8)) + "] \r\n");
                            }
                            if (Math.Abs((double)vpScenarioModel.EffluentConcentration_MPN_100ml - double.Parse(TempTxt.Substring(96, 8))) > 0.1)
                            {
                                return ReturnError(string.Format(ServiceRes._NotEqual, ServiceRes.EffluentConcentration_MPN_100ml) + " [" + vpScenarioModel.EffluentConcentration_MPN_100ml + "] [" + double.Parse(TempTxt.Substring(96, 8)) + "] \r\n");
                            }
                        }
                    }

                    if (TempTxt.Substring(0, 6) == "Simula")
                    {
                        TempTxt = tr.ReadLine();

                        // should verify that the FroudeNumber is not too big
                        vpScenarioModel.FroudeNumber = double.Parse(TempTxt.Substring(19, 6));
                        vpScenarioModel.EffluentVelocity_m_s = double.Parse(TempTxt.Substring(84, 8));
                    }

                    if (TempTxt.Substring(0, 5) == "count")
                    {
                        int count = 0;
                        VPResultModel vpResultModelRet = _VPResultService.PostDeleteVPResultAllWithVPScenarioIDDB(VPScenarioID);
                        if (!string.IsNullOrWhiteSpace(vpResultModelRet.Error))
                            return ReturnError(vpResultModelRet.Error);

                        foreach (VPResValues TempVal in listOfResVal)
                        {
                            if (TempVal.Conc > 13)
                            {
                                count += 1;
                                VPResultModel vpResultModelNew = new VPResultModel();
                                vpResultModelNew.DBCommand = DBCommandEnum.Original;
                                vpResultModelNew.VPScenarioID = VPScenarioID;
                                vpResultModelNew.Concentration_MPN_100ml = TempVal.Conc;
                                vpResultModelNew.Dilution = TempVal.Dilu;
                                vpResultModelNew.DispersionDistance_m = TempVal.Distance;
                                vpResultModelNew.FarFieldWidth_m = TempVal.FarfieldWidth;
                                vpResultModelNew.Ordinal = count;
                                vpResultModelNew.TravelTime_hour = TempVal.TheTime;

                                VPResultModel vpResultModelRet2 = _VPResultService.PostAddVPResultDB(vpResultModelNew);
                                if (!string.IsNullOrWhiteSpace(vpResultModelRet2.Error))
                                    return ReturnError(vpResultModelRet2.Error);
                            }
                        }
                        vpScenarioModel.VPScenarioStatus = ScenarioStatusEnum.Completed;
                        //vpScenarioModel.RawResults = sb.ToString();

                        VPScenarioModel vpScenarioModelRet3 = PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModel);
                        if (!string.IsNullOrWhiteSpace(vpScenarioModelRet3.Error))
                            return ReturnError(vpScenarioModelRet3.Error);

                        vpScenarioModel = PostUpdateVPScenarioRawResultsDB(VPScenarioID, RawResults);
                        if (!string.IsNullOrWhiteSpace(vpScenarioModel.Error))
                            return ReturnError(vpScenarioModel.Error);


                        return ReturnError("");
                    }

                    if (StartReadingValues)
                    {
                        VPResValues TempResValues = new VPResValues();
                        if (IsFirstPart)
                        {

                            if (TempTxt.Length > 14)
                            {
                                if (TempTxt.Substring(0, 13) == "4/3 Power Law" || TempTxt.Substring(0, 13) == "Plumes not me")
                                {
                                    StartReadingValues = false;
                                    IsFirstPart = false;
                                    continue;
                                }
                            }

                            if (TempTxt.Length < 86)
                            {
                                return ReturnError(ServiceRes.PleaseAddTimeUnderSpecialSetting);
                            }

                            TempResValues.FarfieldWidth = double.Parse(TempTxt.Substring(24, 8));
                            if (TempTxt.Substring(33, 8).Contains("E"))
                            {
                                TempResValues.Conc = int.Parse(Decimal.Parse(TempTxt.Substring(33, 8), System.Globalization.NumberStyles.Float).ToString());
                            }
                            else
                            {
                                TempResValues.Conc = (int)float.Parse(TempTxt.Substring(33, 8));
                            }
                            TempResValues.Dilu = double.Parse(TempTxt.Substring(51, 8));
                            TempResValues.Distance = double.Parse(TempTxt.Substring(70, 8));
                            TempResValues.TheTime = double.Parse(TempTxt.Substring(78, 8));
                        }
                        else
                        {
                            TempResValues.Conc = (int)float.Parse(TempTxt.Substring(0, 9));
                            TempResValues.Dilu = double.Parse(TempTxt.Substring(8, 9));
                            TempResValues.FarfieldWidth = double.Parse(TempTxt.Substring(17, 8));
                            TempResValues.Distance = double.Parse(TempTxt.Substring(24, 8));
                            TempResValues.TheTime = double.Parse(TempTxt.Substring(33, 8));

                            if (!GotDecayAlready)
                            {
                                GotDecayAlready = true;
                            }
                        }

                        listOfResVal.Add(TempResValues);
                    }
                    if (string.IsNullOrEmpty(TempTxt))
                        continue;
                    if (TempTxt.Length > 4)
                    {
                        if (TempTxt.Substring(0, 4) == "(col")
                        {
                            StartReadingValues = true;
                            IsFirstPart = false;
                        }
                    }
                    if (TempTxt.Length > 40)
                    {
                        if (TempTxt.Substring(0, 40) == "Step      (m)    (m/s)      (m) (col/dl)")
                        {
                            StartReadingValues = true;

                            IsFirstPart = true;
                        }
                    }
                }
            }
            else
            {
                return ReturnError(ServiceRes.ResultFileIsEmpty);
            }
            return ReturnError("");
        }
        public VPScenarioModel PostSaveVPScenarioDB(FormCollection fc)
        {
            int InfrastructureTVItemID = 0;
            int VPScenarioID = 0;
            bool UseAsBestEstimate = false;
            string VPScenarioName = "";

            int.TryParse(fc["InfrastructureTVItemID"], out InfrastructureTVItemID);
            if (InfrastructureTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID));

            int.TryParse(fc["VPScenarioID"], out VPScenarioID);
            if (VPScenarioID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID));

            bool.TryParse(fc["UseAsBestEstimate"], out UseAsBestEstimate);
            if (UseAsBestEstimate)
            {
                List<VPScenarioModel> vpScenarioModelList = GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);

                foreach (VPScenarioModel vpScenarioModel in vpScenarioModelList)
                {
                    vpScenarioModel.UseAsBestEstimate = false;

                    VPScenarioModel vpScenarioModelRet2 = PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModel);
                    if (!string.IsNullOrWhiteSpace(vpScenarioModelRet2.Error))
                        return ReturnError(vpScenarioModelRet2.Error);
                }
            }

            VPScenarioModel vpScenarioModelToChange = GetVPScenarioModelWithVPScenarioIDDB(VPScenarioID);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelToChange.Error))
                return ReturnError(vpScenarioModelToChange.Error);

            vpScenarioModelToChange.DBCommand = DBCommandEnum.Original;

            VPScenarioName = fc["VPScenarioName"];
            if (string.IsNullOrWhiteSpace(VPScenarioName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioName));

            vpScenarioModelToChange.VPScenarioName = VPScenarioName;
            vpScenarioModelToChange.UseAsBestEstimate = UseAsBestEstimate;

            vpScenarioModelToChange.VPScenarioStatus = ScenarioStatusEnum.Changed;
            vpScenarioModelToChange.PortDiameter_m = null;
            if (fc["PortDiameter_m"] != "")
            {
                vpScenarioModelToChange.PortDiameter_m = double.Parse(fc["PortDiameter_m"]);
            }
            vpScenarioModelToChange.PortElevation_m = null;
            if (fc["PortElevation_m"] != "")
            {
                vpScenarioModelToChange.PortElevation_m = double.Parse(fc["PortElevation_m"]);
            }
            vpScenarioModelToChange.VerticalAngle_deg = null;
            if (fc["VerticalAngle_deg"] != "")
            {
                vpScenarioModelToChange.VerticalAngle_deg = double.Parse(fc["VerticalAngle_deg"]);
            }
            vpScenarioModelToChange.HorizontalAngle_deg = null;
            if (fc["HorizontalAngle_deg"] != "")
            {
                vpScenarioModelToChange.HorizontalAngle_deg = double.Parse(fc["HorizontalAngle_deg"]);
            }
            vpScenarioModelToChange.NumberOfPorts = null;
            if (fc["NumberOfPorts"] != "")
            {
                vpScenarioModelToChange.NumberOfPorts = int.Parse(fc["NumberOfPorts"]);
            }
            vpScenarioModelToChange.PortSpacing_m = null;
            if (fc["PortSpacing_m"] != "")
            {
                vpScenarioModelToChange.PortSpacing_m = double.Parse(fc["PortSpacing_m"]);
            }
            vpScenarioModelToChange.AcuteMixZone_m = null;
            if (fc["AcuteMixZone_m"] != "")
            {
                vpScenarioModelToChange.AcuteMixZone_m = double.Parse(fc["AcuteMixZone_m"]);
            }
            vpScenarioModelToChange.ChronicMixZone_m = null;
            if (fc["ChronicMixZone_m"] != "")
            {
                vpScenarioModelToChange.ChronicMixZone_m = double.Parse(fc["ChronicMixZone_m"]);
            }
            vpScenarioModelToChange.PortDepth_m = null;
            if (fc["PortDepth_m"] != "")
            {
                vpScenarioModelToChange.PortDepth_m = double.Parse(fc["PortDepth_m"]);
            }
            vpScenarioModelToChange.EffluentFlow_m3_s = null;
            if (fc["EffluentFlow_m3_s"] != "")
            {
                vpScenarioModelToChange.EffluentFlow_m3_s = double.Parse(fc["EffluentFlow_m3_s"]);
            }
            vpScenarioModelToChange.EffluentSalinity_PSU = null;
            if (fc["EffluentSalinity_PSU"] != "")
            {
                vpScenarioModelToChange.EffluentSalinity_PSU = double.Parse(fc["EffluentSalinity_PSU"]);
            }
            vpScenarioModelToChange.EffluentTemperature_C = null;
            if (fc["EffluentTemperature_C"] != "")
            {
                vpScenarioModelToChange.EffluentTemperature_C = double.Parse(fc["EffluentTemperature_C"]);
            }
            vpScenarioModelToChange.EffluentConcentration_MPN_100ml = null;
            if (fc["EffluentConcentration_MPN_100ml"] != "")
            {
                vpScenarioModelToChange.EffluentConcentration_MPN_100ml = int.Parse(fc["EffluentConcentration_MPN_100ml"]);
            }

            vpScenarioModelToChange.FroudeNumber = 0;
            vpScenarioModelToChange.EffluentVelocity_m_s = 0;

            VPScenarioModel vpScenarioModelRet = PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModelToChange);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
                return ReturnError(vpScenarioModelRet.Error);

            for (int Row = 1; Row < 9; Row++)
            {

                VPAmbientModel vpAmbientModel = _VPAmbientService.GetVPAmbientModelWithVPScenarioIDAndRowDB(VPScenarioID, Row);
                if (!string.IsNullOrWhiteSpace(vpAmbientModel.Error))
                    return ReturnError(vpAmbientModel.Error);

                vpAmbientModel.MeasurementDepth_m = null;
                if (fc["MeasurementDepth_m" + Row.ToString()] != "")
                {
                    vpAmbientModel.MeasurementDepth_m = double.Parse(fc["MeasurementDepth_m" + Row.ToString()]);
                }
                vpAmbientModel.CurrentSpeed_m_s = null;
                if (fc["CurrentSpeed_m_s" + Row.ToString()] != "")
                {
                    vpAmbientModel.CurrentSpeed_m_s = double.Parse(fc["CurrentSpeed_m_s" + Row.ToString()]);
                }
                vpAmbientModel.CurrentDirection_deg = null;
                if (fc["CurrentDirection_deg" + Row.ToString()] != "")
                {
                    vpAmbientModel.CurrentDirection_deg = double.Parse(fc["CurrentDirection_deg" + Row.ToString()]);
                }
                vpAmbientModel.AmbientSalinity_PSU = null;
                if (fc["AmbientSalinity_PSU" + Row.ToString()] != "")
                {
                    vpAmbientModel.AmbientSalinity_PSU = double.Parse(fc["AmbientSalinity_PSU" + Row.ToString()]);
                }
                vpAmbientModel.AmbientTemperature_C = null;
                if (fc["AmbientTemperature_C" + Row.ToString()] != "")
                {
                    vpAmbientModel.AmbientTemperature_C = double.Parse(fc["AmbientTemperature_C" + Row.ToString()]);
                }
                vpAmbientModel.BackgroundConcentration_MPN_100ml = null;
                if (fc["BackgroundConcentration_MPN_100ml" + Row.ToString()] != "")
                {
                    vpAmbientModel.BackgroundConcentration_MPN_100ml = int.Parse(fc["BackgroundConcentration_MPN_100ml" + Row.ToString()]);
                }
                vpAmbientModel.PollutantDecayRate_per_day = null;
                if (fc["PollutantDecayRate_per_day" + Row.ToString()] != "")
                {
                    vpAmbientModel.PollutantDecayRate_per_day = double.Parse(fc["PollutantDecayRate_per_day" + Row.ToString()]);
                }
                vpAmbientModel.FarFieldCurrentSpeed_m_s = null;
                if (fc["FarFieldCurrentSpeed_m_s" + Row.ToString()] != "")
                {
                    vpAmbientModel.FarFieldCurrentSpeed_m_s = double.Parse(fc["FarFieldCurrentSpeed_m_s" + Row.ToString()]);
                }
                vpAmbientModel.FarFieldCurrentDirection_deg = null;
                if (fc["FarFieldCurrentDirection_deg" + Row.ToString()] != "")
                {
                    vpAmbientModel.FarFieldCurrentDirection_deg = double.Parse(fc["FarFieldCurrentDirection_deg" + Row.ToString()]);
                }
                vpAmbientModel.FarFieldDiffusionCoefficient = null;
                if (fc["FarFieldDiffusionCoefficient" + Row.ToString()] != "")
                {
                    vpAmbientModel.FarFieldDiffusionCoefficient = double.Parse(fc["FarFieldDiffusionCoefficient" + Row.ToString()]);
                }

                VPAmbientModel vpAmbientModelRet = _VPAmbientService.PostUpdateVPAmbientDB(vpAmbientModel);
                if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
                    return ReturnError(vpAmbientModelRet.Error);
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private

        #endregion Functions private
    }
}
