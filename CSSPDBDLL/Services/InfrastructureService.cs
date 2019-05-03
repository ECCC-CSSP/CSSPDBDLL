using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class InfrastructureService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public InfrastructureLanguageService _InfrastructureLanguageService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public InfrastructureService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _InfrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        // Override
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
        public string InfrastructureModelOK(InfrastructureModel infrastructureModel)
        {
            string retStr = FieldCheckNotNullAndMinMaxLengthString(infrastructureModel.InfrastructureTVText, ServiceRes.InfrastructureTVText, 2, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(infrastructureModel.InfrastructureTVItemID, ServiceRes.InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(infrastructureModel.Comment, ServiceRes.Comment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.PrismID, ServiceRes.PrismID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.TPID, ServiceRes.TPID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.LSID, ServiceRes.LSID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.SiteID, ServiceRes.SiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.Site, ServiceRes.Site);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(infrastructureModel.InfrastructureCategory, ServiceRes.InfrastructureCategory, 1);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.InfrastructureTypeOK(infrastructureModel.InfrastructureType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.FacilityTypeOK(infrastructureModel.FacilityType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (infrastructureModel.IsMechanicallyAerated != null)
            {
                retStr = FieldCheckNotNullBool(infrastructureModel.IsMechanicallyAerated, ServiceRes.IsMechanicallyAerated);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(infrastructureModel.NumberOfCells, ServiceRes.NumberOfCells, 0, 7);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(infrastructureModel.NumberOfAeratedCells, ServiceRes.NumberOfAeratedCells, 0, 7);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AerationTypeOK(infrastructureModel.AerationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.PreliminaryTreatmentTypeOK(infrastructureModel.PreliminaryTreatmentType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.PrimaryTreatmentTypeOK(infrastructureModel.PrimaryTreatmentType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SecondaryTreatmentTypeOK(infrastructureModel.SecondaryTreatmentType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TertiaryTreatmentTypeOK(infrastructureModel.TertiaryTreatmentType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TreatmentTypeOK(infrastructureModel.TreatmentType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DisinfectionTypeOK(infrastructureModel.DisinfectionType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.CollectionSystemTypeOK(infrastructureModel.CollectionSystemType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AlarmSystemTypeOK(infrastructureModel.AlarmSystemType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.DesignFlow_m3_day,
                ServiceRes.DesignFlow_m3_day, (double)0.0000001D, (double)10000000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.AverageFlow_m3_day,
                ServiceRes.AverageFlow_m3_day, (double)0.0000001D, (double)10000000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.PeakFlow_m3_day,
                ServiceRes.PeakFlow_m3_day, (double)0.0000001D, (double)10000000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(infrastructureModel.PopServed,
                ServiceRes.PopServed, 5, 100000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (infrastructureModel.CanOverflow != null)
            {
                retStr = FieldCheckNotNullBool(infrastructureModel.CanOverflow, ServiceRes.CanOverflow);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.PercFlowOfTotal,
                ServiceRes.PercFlowOfTotal, (double)0D, (double)100D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.TimeOffset_hour,
                ServiceRes.TimeOffset_hour, (double)-8D, (double)-3D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.AverageDepth_m,
                ServiceRes.AverageDepth_m, (double)0.01D, (double)10000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(infrastructureModel.NumberOfPorts,
                ServiceRes.NumberOfPorts, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.PortDiameter_m,
                ServiceRes.PortDiameter_m, (double)0.01D, (double)10D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.PortSpacing_m,
                ServiceRes.PortSpacing_m, (double)0.01D, (double)10000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.PortElevation_m,
                ServiceRes.PortElevation_m, (double)0.01D, (double)10000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.VerticalAngle_deg,
                ServiceRes.VerticalAngle_deg, (double)-90D, (double)90D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.HorizontalAngle_deg,
                ServiceRes.HorizontalAngle_deg, (double)-180D, (double)180D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.DecayRate_per_day,
                ServiceRes.DecayRate_per_day, (double)0D, (double)1000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.NearFieldVelocity_m_s,
                ServiceRes.NearFieldVelocity_m_s, (double)0D, (double)10D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.FarFieldVelocity_m_s,
                ServiceRes.FarFieldVelocity_m_s, (double)0D, (double)10D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.ReceivingWaterSalinity_PSU,
                ServiceRes.ReceivingWaterSalinity_PSU, (double)0D, (double)35D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.ReceivingWaterTemperature_C,
                ServiceRes.ReceivingWaterTemperature_C, (double)0D, (double)35D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(infrastructureModel.ReceivingWater_MPN_per_100ml,
                ServiceRes.ReceivingWater_MPN_per_100ml, 0, 30000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(infrastructureModel.DistanceFromShore_m,
                ServiceRes.DistanceFromShore_m, (double)0D, (double)10000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.SeeOtherMunicipalityTVItemID, ServiceRes.SeeOtherMunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(infrastructureModel.CivicAddressTVItemID, ServiceRes.CivicAddressTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillInfrastructure(Infrastructure infrastructure, InfrastructureModel infrastructureModel, ContactOK contactOK)
        {
            infrastructure.InfrastructureTVItemID = infrastructureModel.InfrastructureTVItemID;
            infrastructure.PrismID = infrastructureModel.PrismID;
            infrastructure.TPID = infrastructureModel.TPID;
            infrastructure.LSID = infrastructureModel.LSID;
            infrastructure.SiteID = infrastructureModel.SiteID;
            infrastructure.Site = infrastructureModel.Site;
            infrastructure.InfrastructureCategory = infrastructureModel.InfrastructureCategory;

            infrastructure.InfrastructureType = null;
            if (infrastructureModel.InfrastructureType != null)
                infrastructure.InfrastructureType = (int)infrastructureModel.InfrastructureType;

            infrastructure.FacilityType = null;
            if (infrastructureModel.FacilityType != null)
                infrastructure.FacilityType = (int)infrastructureModel.FacilityType;

            infrastructure.IsMechanicallyAerated = infrastructureModel.IsMechanicallyAerated;
            infrastructure.NumberOfCells = infrastructureModel.NumberOfCells;
            infrastructure.NumberOfAeratedCells = infrastructureModel.NumberOfAeratedCells;

            infrastructure.AerationType = null;
            if (infrastructureModel.AerationType != null)
                infrastructure.AerationType = (int)infrastructureModel.AerationType;

            infrastructure.PreliminaryTreatmentType = null;
            if (infrastructureModel.PreliminaryTreatmentType != null)
                infrastructure.PreliminaryTreatmentType = (int)infrastructureModel.PreliminaryTreatmentType;

            infrastructure.PrimaryTreatmentType = null;
            if (infrastructureModel.PrimaryTreatmentType != null)
                infrastructure.PrimaryTreatmentType = (int)infrastructureModel.PrimaryTreatmentType;

            infrastructure.SecondaryTreatmentType = null;
            if (infrastructureModel.SecondaryTreatmentType != null)
                infrastructure.SecondaryTreatmentType = (int)infrastructureModel.SecondaryTreatmentType;

            infrastructure.TertiaryTreatmentType = null;
            if (infrastructureModel.TertiaryTreatmentType != null)
                infrastructure.TertiaryTreatmentType = (int)infrastructureModel.TertiaryTreatmentType;

            infrastructure.TreatmentType = null;
            if (infrastructureModel.TreatmentType != null)
                infrastructure.TreatmentType = (int)infrastructureModel.TreatmentType;

            infrastructure.DisinfectionType = null;
            if (infrastructureModel.DisinfectionType != null)
                infrastructure.DisinfectionType = (int)infrastructureModel.DisinfectionType;

            infrastructure.CollectionSystemType = null;
            if (infrastructureModel.CollectionSystemType != null)
                infrastructure.CollectionSystemType = (int)infrastructureModel.CollectionSystemType;

            infrastructure.AlarmSystemType = null;
            if (infrastructureModel.AlarmSystemType != null)
                infrastructure.AlarmSystemType = (int)infrastructureModel.AlarmSystemType;

            infrastructure.DesignFlow_m3_day = infrastructureModel.DesignFlow_m3_day;
            infrastructure.AverageFlow_m3_day = infrastructureModel.AverageFlow_m3_day;
            infrastructure.PeakFlow_m3_day = infrastructureModel.PeakFlow_m3_day;
            infrastructure.PopServed = infrastructureModel.PopServed;
            infrastructure.CanOverflow = infrastructureModel.CanOverflow;
            infrastructure.PercFlowOfTotal = infrastructureModel.PercFlowOfTotal;
            infrastructure.TimeOffset_hour = infrastructureModel.TimeOffset_hour;
            infrastructure.TempCatchAllRemoveLater = infrastructureModel.TempCatchAllRemoveLater;
            infrastructure.AverageDepth_m = infrastructureModel.AverageDepth_m;
            infrastructure.NumberOfPorts = infrastructureModel.NumberOfPorts;
            infrastructure.PortDiameter_m = infrastructureModel.PortDiameter_m;
            infrastructure.PortSpacing_m = infrastructureModel.PortSpacing_m;
            infrastructure.PortElevation_m = infrastructureModel.PortElevation_m;
            infrastructure.VerticalAngle_deg = infrastructureModel.VerticalAngle_deg;
            infrastructure.HorizontalAngle_deg = infrastructureModel.HorizontalAngle_deg;
            infrastructure.DecayRate_per_day = infrastructureModel.DecayRate_per_day;
            infrastructure.NearFieldVelocity_m_s = infrastructureModel.NearFieldVelocity_m_s;
            infrastructure.FarFieldVelocity_m_s = infrastructureModel.FarFieldVelocity_m_s;
            infrastructure.ReceivingWaterSalinity_PSU = infrastructureModel.ReceivingWaterSalinity_PSU;
            infrastructure.ReceivingWaterTemperature_C = infrastructureModel.ReceivingWaterTemperature_C;
            infrastructure.ReceivingWater_MPN_per_100ml = infrastructureModel.ReceivingWater_MPN_per_100ml;
            infrastructure.DistanceFromShore_m = infrastructureModel.DistanceFromShore_m;
            infrastructure.SeeOtherMunicipalityTVItemID = infrastructureModel.SeeOtherMunicipalityTVItemID;
            infrastructure.CivicAddressTVItemID = infrastructureModel.CivicAddressTVItemID;
            infrastructure.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                infrastructure.LastUpdateContactTVItemID = 2;
            }
            else
            {
                infrastructure.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetInfrastructureModelCountDB()
        {
            int InfrastructureModelCount = (from c in db.Infrastructures
                                            select c).Count();

            return InfrastructureModelCount;
        }
        public InfrastructureModel GetInfrastructureModelWithInfrastructureIDDB(int InfrastructureID)
        {
            InfrastructureModel infrastructureModel = (from c in db.Infrastructures
                                                       let infrastructureTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       let comment = (from cl in db.InfrastructureLanguages where cl.Language == (int)LanguageRequest && cl.InfrastructureID == c.InfrastructureID select cl.Comment).FirstOrDefault<string>()
                                                       where c.InfrastructureID == InfrastructureID
                                                       orderby c.InfrastructureID
                                                       select new InfrastructureModel
                                                       {
                                                           Error = "",
                                                           InfrastructureID = c.InfrastructureID,
                                                           InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                           InfrastructureTVText = infrastructureTVText,
                                                           PrismID = c.PrismID,
                                                           TPID = c.TPID,
                                                           LSID = c.LSID,
                                                           SiteID = c.SiteID,
                                                           Site = c.Site,
                                                           InfrastructureCategory = c.InfrastructureCategory,
                                                           InfrastructureType = (InfrastructureTypeEnum)c.InfrastructureType,
                                                           FacilityType = (FacilityTypeEnum)c.FacilityType,
                                                           IsMechanicallyAerated = c.IsMechanicallyAerated,
                                                           NumberOfCells = c.NumberOfCells,
                                                           NumberOfAeratedCells = c.NumberOfAeratedCells,
                                                           AerationType = (AerationTypeEnum)c.AerationType,
                                                           PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)c.PreliminaryTreatmentType,
                                                           PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)c.PrimaryTreatmentType,
                                                           SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)c.SecondaryTreatmentType,
                                                           TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)c.TertiaryTreatmentType,
                                                           TreatmentType = (TreatmentTypeEnum)c.TreatmentType,
                                                           DisinfectionType = (DisinfectionTypeEnum)c.DisinfectionType,
                                                           CollectionSystemType = (CollectionSystemTypeEnum)c.CollectionSystemType,
                                                           AlarmSystemType = (AlarmSystemTypeEnum)c.AlarmSystemType,
                                                           DesignFlow_m3_day = c.DesignFlow_m3_day,
                                                           AverageFlow_m3_day = c.AverageFlow_m3_day,
                                                           PeakFlow_m3_day = c.PeakFlow_m3_day,
                                                           PopServed = c.PopServed,
                                                           CanOverflow = c.CanOverflow,
                                                           PercFlowOfTotal = c.PercFlowOfTotal,
                                                           TimeOffset_hour = c.TimeOffset_hour,
                                                           TempCatchAllRemoveLater = c.TempCatchAllRemoveLater,
                                                           AverageDepth_m = c.AverageDepth_m,
                                                           NumberOfPorts = c.NumberOfPorts,
                                                           PortDiameter_m = c.PortDiameter_m,
                                                           PortSpacing_m = c.PortSpacing_m,
                                                           PortElevation_m = c.PortElevation_m,
                                                           VerticalAngle_deg = c.VerticalAngle_deg,
                                                           HorizontalAngle_deg = c.HorizontalAngle_deg,
                                                           DecayRate_per_day = c.DecayRate_per_day,
                                                           NearFieldVelocity_m_s = c.NearFieldVelocity_m_s,
                                                           FarFieldVelocity_m_s = c.FarFieldVelocity_m_s,
                                                           ReceivingWaterSalinity_PSU = c.ReceivingWaterSalinity_PSU,
                                                           ReceivingWaterTemperature_C = c.ReceivingWaterTemperature_C,
                                                           ReceivingWater_MPN_per_100ml = c.ReceivingWater_MPN_per_100ml,
                                                           DistanceFromShore_m = c.DistanceFromShore_m,
                                                           Comment = comment,
                                                           SeeOtherMunicipalityTVItemID = c.SeeOtherMunicipalityTVItemID,
                                                           CivicAddressTVItemID = c.CivicAddressTVItemID,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<InfrastructureModel>();

            if (infrastructureModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Infrastructure, ServiceRes.InfrastructureID, InfrastructureID));
            }

            return infrastructureModel;
        }
        public InfrastructureModel GetInfrastructureModelWithInfrastructureTVItemIDDB(int InfrastructureTVItemID)
        {
            InfrastructureModel infrastructureModel = (from c in db.Infrastructures
                                                       let infrastructureTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       let comment = (from cl in db.InfrastructureLanguages where cl.Language == (int)LanguageRequest && cl.InfrastructureID == c.InfrastructureID select cl.Comment).FirstOrDefault<string>()
                                                       where c.InfrastructureTVItemID == InfrastructureTVItemID
                                                       orderby c.InfrastructureID
                                                       select new InfrastructureModel
                                                       {
                                                           Error = "",
                                                           InfrastructureID = c.InfrastructureID,
                                                           InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                           InfrastructureTVText = infrastructureTVText,
                                                           PrismID = c.PrismID,
                                                           TPID = c.TPID,
                                                           LSID = c.LSID,
                                                           SiteID = c.SiteID,
                                                           Site = c.Site,
                                                           InfrastructureCategory = c.InfrastructureCategory,
                                                           InfrastructureType = (InfrastructureTypeEnum)c.InfrastructureType,
                                                           FacilityType = (FacilityTypeEnum)c.FacilityType,
                                                           IsMechanicallyAerated = c.IsMechanicallyAerated,
                                                           NumberOfCells = c.NumberOfCells,
                                                           NumberOfAeratedCells = c.NumberOfAeratedCells,
                                                           AerationType = (AerationTypeEnum)c.AerationType,
                                                           PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)c.PreliminaryTreatmentType,
                                                           PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)c.PrimaryTreatmentType,
                                                           SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)c.SecondaryTreatmentType,
                                                           TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)c.TertiaryTreatmentType,
                                                           TreatmentType = (TreatmentTypeEnum)c.TreatmentType,
                                                           DisinfectionType = (DisinfectionTypeEnum)c.DisinfectionType,
                                                           CollectionSystemType = (CollectionSystemTypeEnum)c.CollectionSystemType,
                                                           AlarmSystemType = (AlarmSystemTypeEnum)c.AlarmSystemType,
                                                           DesignFlow_m3_day = c.DesignFlow_m3_day,
                                                           AverageFlow_m3_day = c.AverageFlow_m3_day,
                                                           PeakFlow_m3_day = c.PeakFlow_m3_day,
                                                           PopServed = c.PopServed,
                                                           CanOverflow = c.CanOverflow,
                                                           PercFlowOfTotal = c.PercFlowOfTotal,
                                                           TimeOffset_hour = c.TimeOffset_hour,
                                                           TempCatchAllRemoveLater = c.TempCatchAllRemoveLater,
                                                           AverageDepth_m = c.AverageDepth_m,
                                                           NumberOfPorts = c.NumberOfPorts,
                                                           PortDiameter_m = c.PortDiameter_m,
                                                           PortSpacing_m = c.PortSpacing_m,
                                                           PortElevation_m = c.PortElevation_m,
                                                           VerticalAngle_deg = c.VerticalAngle_deg,
                                                           HorizontalAngle_deg = c.HorizontalAngle_deg,
                                                           DecayRate_per_day = c.DecayRate_per_day,
                                                           NearFieldVelocity_m_s = c.NearFieldVelocity_m_s,
                                                           FarFieldVelocity_m_s = c.FarFieldVelocity_m_s,
                                                           ReceivingWaterSalinity_PSU = c.ReceivingWaterSalinity_PSU,
                                                           ReceivingWaterTemperature_C = c.ReceivingWaterTemperature_C,
                                                           ReceivingWater_MPN_per_100ml = c.ReceivingWater_MPN_per_100ml,
                                                           DistanceFromShore_m = c.DistanceFromShore_m,
                                                           Comment = comment,
                                                           SeeOtherMunicipalityTVItemID = c.SeeOtherMunicipalityTVItemID,
                                                           CivicAddressTVItemID = c.CivicAddressTVItemID,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<InfrastructureModel>();

            if (infrastructureModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Infrastructure, ServiceRes.InfrastructureTVItemID, InfrastructureTVItemID));
            }
            return infrastructureModel;
        }
        public Infrastructure GetInfrastructureWithInfrastructureIDDB(int InfrastructureID)
        {
            Infrastructure infrastructure = (from c in db.Infrastructures
                                             where c.InfrastructureID == InfrastructureID
                                             select c).FirstOrDefault<Infrastructure>();

            return infrastructure;
        }
        public List<TVItemModelInfrastructureTypeTVItemLinkModel> GetInfrastructureTVItemAndTVItemLinkAndInfrastructureTypeListWithMunicipalityTVItemIDDB(int MunicipalityTVItemID)
        {
            List<TVItemModelInfrastructureTypeTVItemLinkModel> tvItemModelInfrastructureTypeTVItemLinkModelList = new List<TVItemModelInfrastructureTypeTVItemLinkModel>();

            List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MunicipalityTVItemID, TVTypeEnum.Infrastructure);

            foreach (TVItemModel tvItemModel in tvItemModelList)
            {
                InfrastructureTypeEnum infrastructureType = InfrastructureTypeEnum.Other;

                InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModel.TVItemID);
                if (string.IsNullOrWhiteSpace(infrastructureModel.Error))
                {
                    if (infrastructureModel.InfrastructureType != null)
                    {
                        infrastructureType = (InfrastructureTypeEnum)infrastructureModel.InfrastructureType;
                    }
                }

                List<TVItemLinkModel> tvItemLinkModelList = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(tvItemModel.TVItemID);

                TVItemModelInfrastructureTypeTVItemLinkModel tvItemModelInfrastructureTypeTVItemLinkModel = new TVItemModelInfrastructureTypeTVItemLinkModel()
                {
                    TVItemModel = tvItemModel,
                    InfrastructureType = infrastructureType,
                    TVItemModelLinkList = tvItemLinkModelList,
                    SeeOtherMunicipalityTVItemID = infrastructureModel.SeeOtherMunicipalityTVItemID,
                };

                tvItemModelInfrastructureTypeTVItemLinkModelList.Add(tvItemModelInfrastructureTypeTVItemLinkModel);
            }

            foreach (TVItemModelInfrastructureTypeTVItemLinkModel tvItemModelInfrastructureTypeTVItemLinkModel in tvItemModelInfrastructureTypeTVItemLinkModelList.Where(c => c.InfrastructureType != InfrastructureTypeEnum.Other))
            {
                if (tvItemModelInfrastructureTypeTVItemLinkModel.InfrastructureType != InfrastructureTypeEnum.Other)
                {
                    tvItemModelInfrastructureTypeTVItemLinkModel.FlowTo = (from c in tvItemModelInfrastructureTypeTVItemLinkModelList
                                                                           from t in tvItemModelInfrastructureTypeTVItemLinkModel.TVItemModelLinkList
                                                                           where c.TVItemModel.TVItemID == t.ToTVItemID
                                                                           select c).FirstOrDefault();
                }
            }

            List<TVItemModelInfrastructureTypeTVItemLinkModel> tvItemModelInfrastructureTypeTVItemLinkModelListToSend = new List<TVItemModelInfrastructureTypeTVItemLinkModel>();

            foreach (TVItemModelInfrastructureTypeTVItemLinkModel tvItemModelInfrastructureTypeTVItemLinkModel in tvItemModelInfrastructureTypeTVItemLinkModelList.Where(c => c.FlowTo == null && c.InfrastructureType != InfrastructureTypeEnum.Other).ToList())
            {
                tvItemModelInfrastructureTypeTVItemLinkModelFlowTo(tvItemModelInfrastructureTypeTVItemLinkModel, tvItemModelInfrastructureTypeTVItemLinkModelList, tvItemModelInfrastructureTypeTVItemLinkModelListToSend);
            }

            foreach (TVItemModelInfrastructureTypeTVItemLinkModel tvItemModelInfrastructureTypeTVItemLinkModel in tvItemModelInfrastructureTypeTVItemLinkModelList)
            {
                tvItemModelInfrastructureTypeTVItemLinkModelListToSend.Add(tvItemModelInfrastructureTypeTVItemLinkModel);
            }

            return tvItemModelInfrastructureTypeTVItemLinkModelListToSend;
        }
        public void tvItemModelInfrastructureTypeTVItemLinkModelFlowTo(TVItemModelInfrastructureTypeTVItemLinkModel tvItemModelInfrastructureTypeTVItemLinkModel, List<TVItemModelInfrastructureTypeTVItemLinkModel> tvItemModelInfrastructureTypeTVItemLinkModelList, List<TVItemModelInfrastructureTypeTVItemLinkModel> tvItemModelInfrastructureTypeTVItemLinkModelListToSend)
        {
            tvItemModelInfrastructureTypeTVItemLinkModelListToSend.Add(tvItemModelInfrastructureTypeTVItemLinkModel);
            tvItemModelInfrastructureTypeTVItemLinkModelList.Remove(tvItemModelInfrastructureTypeTVItemLinkModel);

            foreach (TVItemModelInfrastructureTypeTVItemLinkModel tvItemModelInfrastructureTypeTVItemLinkModelNext in tvItemModelInfrastructureTypeTVItemLinkModelList.Where(c => c.FlowTo == tvItemModelInfrastructureTypeTVItemLinkModel).ToList())
            {
                tvItemModelInfrastructureTypeTVItemLinkModelFlowTo(tvItemModelInfrastructureTypeTVItemLinkModelNext, tvItemModelInfrastructureTypeTVItemLinkModelList, tvItemModelInfrastructureTypeTVItemLinkModelListToSend);
            }
        }
        // Helper
        public string CreateTVText(InfrastructureModel infrastructureModel)
        {
            return infrastructureModel.InfrastructureTVText;
        }
        public InfrastructureModel ReturnError(string Error)
        {
            return new InfrastructureModel() { Error = Error };
        }

        // Post
        public InfrastructureModel InfrastructureAddOrModifyDB(FormCollection fc)
        {
            int tempInt = 0;
            string InfrastructureTVText = "";
            int TVItemIDMunicipality = 0;
            int InfrastructureTVItemID = 0;
            double Lat = 0.0D;
            double Lng = 0.0D;
            double? LatOutfall = null;
            double? LngOutfall = null;
            int SeeOtherMunicipalityTVItemID = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);


            InfrastructureTVText = fc["InfrastructureTVText"];
            if (string.IsNullOrWhiteSpace(InfrastructureTVText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVText));

            if (InfrastructureTVText.Contains("#"))
                return ReturnError(string.Format(ServiceRes.NameOfItemShouldNotContainThe_Character, "#"));


            int.TryParse(fc["TVItemIDMunicipality"], out TVItemIDMunicipality);
            if (TVItemIDMunicipality == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemIDMunicipality));

            TVItemModel tvItemModelMuni = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemIDMunicipality);
            if (!string.IsNullOrWhiteSpace(tvItemModelMuni.Error))
                return ReturnError(tvItemModelMuni.Error);

            int.TryParse(fc["InfrastructureTVItemID"], out InfrastructureTVItemID);
            // could be 0 if 0 then we need to add the new Infrastructure 

            InfrastructureModel infrastructureNewOrToChange = new InfrastructureModel();

            infrastructureNewOrToChange.InfrastructureTVItemID = InfrastructureTVItemID;

            if (InfrastructureTVItemID > 0)
            {
                infrastructureNewOrToChange = GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(infrastructureNewOrToChange.Error))
                    return ReturnError(infrastructureNewOrToChange.Error);
            }

            if (string.IsNullOrWhiteSpace(fc["InfrastructureType"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureType));
            else
            {
                int.TryParse(fc["InfrastructureType"], out tempInt);
                infrastructureNewOrToChange.InfrastructureType = (InfrastructureTypeEnum)tempInt;
            }

            infrastructureNewOrToChange.InfrastructureTVText = InfrastructureTVText;

            infrastructureNewOrToChange.SeeOtherMunicipalityTVItemID = null;

            if (infrastructureNewOrToChange.InfrastructureType == InfrastructureTypeEnum.SeeOtherMunicipality)
            {
                int.TryParse(fc["SeeOtherMunicipalityTVItemID"], out SeeOtherMunicipalityTVItemID);
                if (SeeOtherMunicipalityTVItemID > 0)
                    infrastructureNewOrToChange.SeeOtherMunicipalityTVItemID = SeeOtherMunicipalityTVItemID;

                TVItemModel tvItemModelMunicipality = _TVItemService.GetTVItemModelWithTVItemIDDB(SeeOtherMunicipalityTVItemID);

                if (tvItemModelMuni.TVItemID == SeeOtherMunicipalityTVItemID)
                    return ReturnError(ServiceRes.SeeOtherMunicipalityShouldBeReferingToAnotherMunicipality);

                if (tvItemModelMunicipality.TVType != TVTypeEnum.Municipality)
                    return ReturnError(ServiceRes.SeeOtherMunicipalityShouldBeReferingToAnotherMunicipality);

                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Municipality, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    Lat = mapInfoPointModelList[0].Lat;
                    Lng = mapInfoPointModelList[0].Lng;
                }
            }
            else
            {
                double.TryParse(fc["Lat"], out Lat);
                if (Lat == 0.0D)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));

                double.TryParse(fc["Lng"], out Lng);
                if (Lng == 0.0D)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));

                if (!string.IsNullOrWhiteSpace(fc["LatOutfall"]))
                {
                    LatOutfall = double.Parse(fc["LatOutfall"]);
                }
                if (!string.IsNullOrWhiteSpace(fc["LngOutfall"]))
                {
                    LngOutfall = double.Parse(fc["LngOutfall"]);
                }

            }

            InfrastructureModel infrastructureModelRet = new InfrastructureModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (InfrastructureTVItemID == 0)
                {
                    TVItemModel tvItemModelNewInfrastructure = _TVItemService.PostAddChildTVItemDB(TVItemIDMunicipality, InfrastructureTVText, TVTypeEnum.Infrastructure);
                    if (!string.IsNullOrWhiteSpace(tvItemModelNewInfrastructure.Error))
                        return ReturnError(tvItemModelNewInfrastructure.Error);

                    infrastructureNewOrToChange.InfrastructureTVItemID = tvItemModelNewInfrastructure.TVItemID;

                    infrastructureModelRet = PostAddInfrastructureDB(infrastructureNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                        return ReturnError(infrastructureModelRet.Error);
                }
                else
                {
                    infrastructureModelRet = PostUpdateInfrastructureDB(infrastructureNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                        return ReturnError(infrastructureModelRet.Error);
                }

                List<MapInfoPointModel> mapInfoPointModelList = new List<MapInfoPointModel>();

                TVTypeEnum tvType = TVTypeEnum.Error;
                if (infrastructureModelRet.InfrastructureType == InfrastructureTypeEnum.WWTP)
                {
                    tvType = TVTypeEnum.WasteWaterTreatmentPlant;
                }
                else if (infrastructureModelRet.InfrastructureType == InfrastructureTypeEnum.LiftStation)
                {
                    tvType = TVTypeEnum.LiftStation;
                }
                else if (infrastructureModelRet.InfrastructureType == InfrastructureTypeEnum.Other)
                {
                    tvType = TVTypeEnum.OtherInfrastructure;
                }
                else if (infrastructureModelRet.InfrastructureType == InfrastructureTypeEnum.SeeOtherMunicipality)
                {
                    tvType = TVTypeEnum.SeeOtherMunicipality;
                }
                else if (infrastructureModelRet.InfrastructureType == InfrastructureTypeEnum.LineOverflow)
                {
                    tvType = TVTypeEnum.LineOverflow;
                }

                InfrastructureModel infrastructureModelRet2 = InfrastructureCoordinateUpdateDB(infrastructureModelRet, tvType, (float)Lat, (float)Lng, (float?)LatOutfall, (float?)LngOutfall);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet2.Error))
                    return ReturnError(infrastructureModelRet2.Error);

                InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModelRet, tvType, (float)Lat, (float)Lng);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                    return ReturnError(infrastructureModelRet3.Error);


                ts.Complete();
            }
            return infrastructureModelRet;
        }
        public InfrastructureModel InfrastructureTVItemLinkPolylineUpdateDB(InfrastructureModel infrastructureModel, TVTypeEnum tvType, float Lat, float Lng)
        {
            List<Coord> coordList = new List<Coord>();

            // doing From
            List<TVItemLinkModel> tvItemLinkModelFromList = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(infrastructureModel.InfrastructureTVItemID);
            if (tvItemLinkModelFromList.Count > 0)
            {
                int TVItemIDFrom = 0;
                int TVItemIDTo = 0;
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelFromList)
                {
                    if (tvItemLinkModel.FromTVType == TVTypeEnum.Infrastructure && tvItemLinkModel.ToTVType == TVTypeEnum.Infrastructure)
                    {
                        TVItemIDFrom = tvItemLinkModel.FromTVItemID;
                        TVItemIDTo = tvItemLinkModel.ToTVItemID;
                        break;
                    }
                }

                InfrastructureModel infrastructureModelTo = GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemIDTo);
                if (!string.IsNullOrWhiteSpace(infrastructureModelTo.Error))
                    return ReturnError(infrastructureModelTo.Error);

                TVTypeEnum tvTypeTo = TVTypeEnum.Error;
                switch (infrastructureModel.InfrastructureType)
                {
                    case InfrastructureTypeEnum.LiftStation:
                        {
                            tvTypeTo = TVTypeEnum.LiftStation;
                        }
                        break;
                    case InfrastructureTypeEnum.WWTP:
                        {
                            tvTypeTo = TVTypeEnum.WasteWaterTreatmentPlant;
                        }
                        break;
                    case InfrastructureTypeEnum.LineOverflow:
                        {
                            tvTypeTo = TVTypeEnum.LineOverflow;
                        }
                        break;
                    case InfrastructureTypeEnum.Other:
                        {
                            tvTypeTo = TVTypeEnum.OtherInfrastructure;
                        }
                        break;
                    case InfrastructureTypeEnum.SeeOtherMunicipality:
                        {
                            tvTypeTo = TVTypeEnum.SeeOtherMunicipality;
                        }
                        break;
                    default:
                        break;
                }

                List<MapInfoPointModel> mapInfoPointModelListFrom = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDFrom, tvType, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelListFrom.Count == 0)
                {
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfoPoint, ServiceRes.TVItemID + "," + ServiceRes.TVType + "," + BaseEnumServiceRes.MapInfoDrawTypeEnumPoint, TVItemIDFrom.ToString() + "," + tvType.ToString() + "," + MapInfoDrawTypeEnum.Point.ToString()));
                }

                List<MapInfoPointModel> mapInfoPointModelListTo = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDTo, tvTypeTo, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelListTo.Count == 0)
                {
                    // nothing can have count == 0
                }

                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDFrom, tvType, MapInfoDrawTypeEnum.Polyline);
                if (mapInfoPointModelList.Count == 0)
                {
                    coordList = new List<Coord>();
                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModelListFrom[0].Lat, Lng = (float)mapInfoPointModelListFrom[0].Lng, Ordinal = 0 });
                    if (mapInfoPointModelListTo.Count > 0)
                    {
                        coordList.Add(new Coord() { Lat = (float)mapInfoPointModelListTo[0].Lat, Lng = (float)mapInfoPointModelListTo[0].Lng, Ordinal = 1 });
                    }
                    else
                    {
                        coordList.Add(new Coord() { Lat = (float)mapInfoPointModelListFrom[0].Lat + 0.0001f, Lng = (float)mapInfoPointModelListFrom[0].Lng + 0.0001f, Ordinal = 1 });
                    }

                    bool OneOfDifferentTypeExist = false;
                    foreach (TVTypeEnum tvTypeItem in new List<TVTypeEnum>() { TVTypeEnum.WasteWaterTreatmentPlant, TVTypeEnum.LiftStation, TVTypeEnum.LineOverflow, TVTypeEnum.OtherInfrastructure, TVTypeEnum.SeeOtherMunicipality })
                    {
                        List<MapInfoPointModel> mapInfoPointModelListExist = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDFrom, tvTypeItem, MapInfoDrawTypeEnum.Polyline);
                        if (mapInfoPointModelListExist.Count > 0)
                        {
                            MapInfoModel mapInfoModel = _MapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelListExist[0].MapInfoID);
                            mapInfoModel.TVType = tvType;
                            MapInfoModel mapInfoModelRet = _MapInfoService.PostUpdateMapInfoDB(mapInfoModel);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                            {
                                return ReturnError(mapInfoModelRet.Error);
                            }
                            OneOfDifferentTypeExist = true;
                            break;
                        }
                    }

                    if (!OneOfDifferentTypeExist)
                    {
                        MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, tvType, TVItemIDFrom);
                        if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                            return ReturnError(mapInfoModelRet.Error);
                    }
                }
                else
                {
                    mapInfoPointModelList[0].Lat = mapInfoPointModelListFrom[0].Lat;
                    mapInfoPointModelList[0].Lng = mapInfoPointModelListFrom[0].Lng;

                    MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        return ReturnError(mapInfoPointModelRet.Error);

                    if (mapInfoPointModelListTo.Count > 0)
                    {
                        mapInfoPointModelList[mapInfoPointModelList.Count - 1].Lat = mapInfoPointModelListTo[0].Lat;
                        mapInfoPointModelList[mapInfoPointModelList.Count - 1].Lng = mapInfoPointModelListTo[0].Lng;

                        mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[mapInfoPointModelList.Count - 1]);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);
                    }
                }
            }

            // doing To
            List<TVItemLinkModel> tvItemLinkModelToList = _TVItemLinkService.GetTVItemLinkModelListWithToTVItemIDDB(infrastructureModel.InfrastructureTVItemID);
            foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelToList)
            {
                if (tvItemLinkModel.FromTVType == TVTypeEnum.Infrastructure && tvItemLinkModel.ToTVType == TVTypeEnum.Infrastructure)
                {
                    int TVItemIDFrom = tvItemLinkModel.FromTVItemID;
                    int TVItemIDTo = tvItemLinkModel.ToTVItemID;

                    InfrastructureModel infrastructureModelFrom = GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemIDFrom);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelFrom.Error))
                        return ReturnError(infrastructureModelFrom.Error);

                    TVTypeEnum tvTypeTo = TVTypeEnum.Error;

                    switch (infrastructureModelFrom.InfrastructureType)
                    {
                        case InfrastructureTypeEnum.LiftStation:
                            {
                                tvType = TVTypeEnum.LiftStation;
                            }
                            break;
                        case InfrastructureTypeEnum.WWTP:
                            {
                                tvType = TVTypeEnum.WasteWaterTreatmentPlant;
                            }
                            break;
                        case InfrastructureTypeEnum.LineOverflow:
                            {
                                tvType = TVTypeEnum.LineOverflow;
                            }
                            break;
                        case InfrastructureTypeEnum.Other:
                            {
                                tvType = TVTypeEnum.OtherInfrastructure;
                            }
                            break;
                        case InfrastructureTypeEnum.SeeOtherMunicipality:
                            {
                                tvType = TVTypeEnum.SeeOtherMunicipality;
                            }
                            break;
                        default:
                            break;
                    }

                    InfrastructureModel infrastructureModelTo = GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemIDTo);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelTo.Error))
                        return ReturnError(infrastructureModelTo.Error);

                    switch (infrastructureModelTo.InfrastructureType)
                    {
                        case InfrastructureTypeEnum.LiftStation:
                            {
                                tvTypeTo = TVTypeEnum.LiftStation;
                            }
                            break;
                        case InfrastructureTypeEnum.WWTP:
                            {
                                tvTypeTo = TVTypeEnum.WasteWaterTreatmentPlant;
                            }
                            break;
                        case InfrastructureTypeEnum.LineOverflow:
                            {
                                tvTypeTo = TVTypeEnum.LineOverflow;
                            }
                            break;
                        case InfrastructureTypeEnum.Other:
                            {
                                tvTypeTo = TVTypeEnum.OtherInfrastructure;
                            }
                            break;
                        case InfrastructureTypeEnum.SeeOtherMunicipality:
                            {
                                tvTypeTo = TVTypeEnum.SeeOtherMunicipality;
                            }
                            break;
                        default:
                            break;
                    }

                    List<MapInfoPointModel> mapInfoPointModelListFrom = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDFrom, tvType, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelListFrom.Count == 0)
                        return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfoPoint, ServiceRes.TVItemID + "," + ServiceRes.TVType + "," + BaseEnumServiceRes.MapInfoDrawTypeEnumPoint, TVItemIDFrom.ToString() + "," + tvType.ToString() + "," + MapInfoDrawTypeEnum.Point.ToString()));

                    List<MapInfoPointModel> mapInfoPointModelListTo = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDTo, tvTypeTo, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelListFrom.Count == 0)
                        return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfoPoint, ServiceRes.TVItemID + "," + ServiceRes.TVType + "," + BaseEnumServiceRes.MapInfoDrawTypeEnumPoint, TVItemIDTo.ToString() + "," + tvType.ToString() + "," + MapInfoDrawTypeEnum.Point.ToString()));

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDFrom, tvType, MapInfoDrawTypeEnum.Polyline);
                    if (mapInfoPointModelList.Count == 0)
                    {
                        coordList = new List<Coord>();
                        coordList.Add(new Coord() { Lat = (float)mapInfoPointModelListFrom[0].Lat, Lng = (float)mapInfoPointModelListFrom[0].Lng, Ordinal = 0 });
                        coordList.Add(new Coord() { Lat = (float)mapInfoPointModelListTo[0].Lat, Lng = (float)mapInfoPointModelListTo[0].Lng, Ordinal = 1 });

                        bool OneOfDifferentTypeExist = false;
                        foreach (TVTypeEnum tvTypeItem in new List<TVTypeEnum>() { TVTypeEnum.WasteWaterTreatmentPlant, TVTypeEnum.LiftStation, TVTypeEnum.LineOverflow, TVTypeEnum.OtherInfrastructure, TVTypeEnum.SeeOtherMunicipality })
                        {
                            List<MapInfoPointModel> mapInfoPointModelListExist = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemIDFrom, tvTypeItem, MapInfoDrawTypeEnum.Polyline);
                            if (mapInfoPointModelListExist.Count > 0)
                            {
                                MapInfoModel mapInfoModel = _MapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelListExist[0].MapInfoID);
                                mapInfoModel.TVType = tvType;
                                MapInfoModel mapInfoModelRet = _MapInfoService.PostUpdateMapInfoDB(mapInfoModel);
                                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                                {
                                    return ReturnError(mapInfoModelRet.Error);
                                }
                                OneOfDifferentTypeExist = true;
                                break;
                            }
                        }

                        if (!OneOfDifferentTypeExist)
                        {
                            MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, tvType, TVItemIDFrom);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                                return ReturnError(mapInfoModelRet.Error);
                        }
                    }
                    else
                    {
                        mapInfoPointModelList[mapInfoPointModelList.Count - 1].Lat = Lat;
                        mapInfoPointModelList[mapInfoPointModelList.Count - 1].Lng = Lng;

                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[mapInfoPointModelList.Count - 1]);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);
                    }
                }
            }

            return ReturnError("");
        }
        public InfrastructureModel InfrastructureCoordinateUpdateDB(InfrastructureModel infrastructureModelRet, TVTypeEnum tvType, float Lat, float Lng, float? LatOutfall, float? LngOutfall)
        {
            List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)Lat, Lng = (float)Lng, Ordinal = 0 } };

            // Infrastructure point
            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count == 0)
            {
                coordList = new List<Coord>();
                coordList.Add(new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 });

                bool OneOfDifferentTypeExist = false;
                foreach(TVTypeEnum tvTypeItem in new List<TVTypeEnum>() { TVTypeEnum.WasteWaterTreatmentPlant, TVTypeEnum.LiftStation, TVTypeEnum.LineOverflow, TVTypeEnum.OtherInfrastructure, TVTypeEnum.SeeOtherMunicipality })
                {
                    List<MapInfoPointModel> mapInfoPointModelListExist = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeItem, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelListExist.Count > 0)
                    {
                        MapInfoModel mapInfoModel = _MapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelListExist[0].MapInfoID);
                        mapInfoModel.TVType = tvType;
                        MapInfoModel mapInfoModelRet = _MapInfoService.PostUpdateMapInfoDB(mapInfoModel);
                        if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        {
                            return ReturnError(mapInfoModelRet.Error);
                        }
                        OneOfDifferentTypeExist = true;
                        break;
                    }
                }

                if (!OneOfDifferentTypeExist)
                {
                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, tvType, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }
            }
            else
            {
                mapInfoPointModelList[0].Lat = Lat;
                mapInfoPointModelList[0].Lng = Lng;

                MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    return ReturnError(mapInfoPointModelRet.Error);
            }

            // Infrastructure outfall point
            List<MapInfoPointModel> mapInfoPointModelListOutfall = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelListOutfall.Count == 0)
            {
                if (LatOutfall != null && LngOutfall != null)
                {
                    coordList = new List<Coord>();
                    coordList.Add(new Coord() { Lat = (float)LatOutfall, Lng = (float)LngOutfall, Ordinal = 0 });
                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Outfall, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }
            }
            else
            {
                if (LatOutfall != null && LngOutfall != null)
                {
                    mapInfoPointModelListOutfall[0].Lat = (float)LatOutfall;
                    mapInfoPointModelListOutfall[0].Lng = (float)LngOutfall;
                }

                MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelListOutfall[0]);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    return ReturnError(mapInfoPointModelRet.Error);
            }

            // Infrastructure Polyline between infrastructure and outfall
            List<MapInfoPointModel> mapInfoPointModelListPolyline = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
            if (mapInfoPointModelListPolyline.Count == 0)
            {
                if (LatOutfall != null && LngOutfall != null)
                {
                    coordList = new List<Coord>();
                    coordList.Add(new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 });
                    coordList.Add(new Coord() { Lat = (float)LatOutfall, Lng = (float)LngOutfall, Ordinal = 0 });

                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.Outfall, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }
            }
            else
            {
                mapInfoPointModelListPolyline[0].Lat = Lat;
                mapInfoPointModelListPolyline[0].Lng = Lng;

                MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelListPolyline[0]);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    return ReturnError(mapInfoPointModelRet.Error);

                if (LatOutfall != null && LngOutfall != null)
                {
                    mapInfoPointModelListPolyline[mapInfoPointModelListPolyline.Count - 1].Lat = (float)LatOutfall;
                    mapInfoPointModelListPolyline[mapInfoPointModelListPolyline.Count - 1].Lng = (float)LngOutfall;

                    mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelListPolyline[mapInfoPointModelListPolyline.Count - 1]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        return ReturnError(mapInfoPointModelRet.Error);
                }
                else
                {
                    MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoDB(mapInfoPointModelListPolyline[0].MapInfoID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                        return ReturnError(mapInfoModel.Error);
                }

            }

            return ReturnError("");
        }
        public InfrastructureModel InfrastructureSaveAllDB(FormCollection fc)
        {
            int tempInt = 0;
            string InfrastructureTVText = "";
            int InfrastructureTVItemID = 0;
            double DesignFlow_m3_day = 0.0D;
            double AverageFlow_m3_day = 0.0D;
            double PeakFlow_m3_day = 0.0D;
            int PopServed = 0;
            double PercFlowOfTotal = 0.0D;
            double AverageDepth_m = 0.0D;
            int NumberOfPorts = 0;
            double PortDiameter_m = 0.0D;
            double PortSpacing_m = 0.0D;
            double PortElevation_m = 0.0D;
            double VerticalAngle_deg = 0.0D;
            double HorizontalAngle_deg = 0.0D;
            double DecayRate_per_day = 0.0D;
            double NearFieldVelocity_m_s = 0.0D;
            double FarFieldVelocity_m_s = 0.0D;
            double ReceivingWaterSalinity_PSU = 0.0D;
            double ReceivingWaterTemperature_C = 0.0D;
            int ReceivingWater_MPN_per_100ml = 0;
            double DistanceFromShore_m = 0.0D;
            double Lat = 0.0D;
            double Lng = 0.0D;
            double LatOutfall = 0.0D;
            double LngOutfall = 0.0D;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            InfrastructureTVText = fc["InfrastructureTVText"];
            if (string.IsNullOrWhiteSpace(InfrastructureTVText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVText));

            int.TryParse(fc["InfrastructureTVItemID"], out InfrastructureTVItemID);
            if (InfrastructureTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID));

            InfrastructureModel infrastructureModelToChange = GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(infrastructureModelToChange.Error))
                return ReturnError(infrastructureModelToChange.Error);

            infrastructureModelToChange.InfrastructureCategory = fc["InfrastructureCategory"];


            if (string.IsNullOrWhiteSpace(fc["InfrastructureType"]))
                infrastructureModelToChange.InfrastructureType = null;
            else
            {
                int.TryParse(fc["InfrastructureType"], out tempInt);
                infrastructureModelToChange.InfrastructureType = (InfrastructureTypeEnum)tempInt;
            }

            if (string.IsNullOrWhiteSpace(fc["FacilityType"]))
                infrastructureModelToChange.FacilityType = null;
            else
            {
                int.TryParse(fc["FacilityType"], out tempInt);
                infrastructureModelToChange.FacilityType = (FacilityTypeEnum)tempInt;
            }

            if (infrastructureModelToChange.FacilityType == FacilityTypeEnum.Lagoon)
            {
                if (string.IsNullOrWhiteSpace(fc["IsMechanicallyAerated"]))
                    infrastructureModelToChange.IsMechanicallyAerated = false;
                else
                {
                    infrastructureModelToChange.IsMechanicallyAerated = true;
                }

                if (string.IsNullOrWhiteSpace(fc["NumberOfCells"]))
                    infrastructureModelToChange.NumberOfCells = null;
                else
                {
                    infrastructureModelToChange.NumberOfCells = int.Parse(fc["NumberOfCells"]);
                }

                if (string.IsNullOrWhiteSpace(fc["NumberOfAeratedCells"]))
                    infrastructureModelToChange.NumberOfAeratedCells = null;
                else
                {
                    infrastructureModelToChange.NumberOfAeratedCells = int.Parse(fc["NumberOfAeratedCells"]);
                }

                if (string.IsNullOrWhiteSpace(fc["AerationType"]))
                    infrastructureModelToChange.AerationType = null;
                else
                {
                    int.TryParse(fc["AerationType"], out tempInt);
                    infrastructureModelToChange.AerationType = (AerationTypeEnum)tempInt;
                }

                infrastructureModelToChange.PreliminaryTreatmentType = null;
                infrastructureModelToChange.PrimaryTreatmentType = null;
                infrastructureModelToChange.SecondaryTreatmentType = null;
                infrastructureModelToChange.TertiaryTreatmentType = null;
            }

            if (infrastructureModelToChange.FacilityType == FacilityTypeEnum.Plant)
            {
                if (string.IsNullOrWhiteSpace(fc["PreliminaryTreatmentType"]))
                    infrastructureModelToChange.PreliminaryTreatmentType = null;
                else
                {
                    int.TryParse(fc["PreliminaryTreatmentType"], out tempInt);
                    infrastructureModelToChange.PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)tempInt;
                }

                if (string.IsNullOrWhiteSpace(fc["PrimaryTreatmentType"]))
                    infrastructureModelToChange.PrimaryTreatmentType = null;
                else
                {
                    int.TryParse(fc["PrimaryTreatmentType"], out tempInt);
                    infrastructureModelToChange.PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)tempInt;
                }

                if (string.IsNullOrWhiteSpace(fc["SecondaryTreatmentType"]))
                    infrastructureModelToChange.SecondaryTreatmentType = null;
                else
                {
                    int.TryParse(fc["SecondaryTreatmentType"], out tempInt);
                    infrastructureModelToChange.SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)tempInt;
                }

                if (string.IsNullOrWhiteSpace(fc["TertiaryTreatmentType"]))
                    infrastructureModelToChange.TertiaryTreatmentType = null;
                else
                {
                    int.TryParse(fc["TertiaryTreatmentType"], out tempInt);
                    infrastructureModelToChange.TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)tempInt;
                }

            }

            if (string.IsNullOrWhiteSpace(fc["DisinfectionType"]))
                infrastructureModelToChange.DisinfectionType = null;
            else
            {
                int.TryParse(fc["DisinfectionType"], out tempInt);
                infrastructureModelToChange.DisinfectionType = (DisinfectionTypeEnum)tempInt;
            }

            if (string.IsNullOrWhiteSpace(fc["CollectionSystemType"]))
                infrastructureModelToChange.CollectionSystemType = null;
            else
            {
                int.TryParse(fc["CollectionSystemType"], out tempInt);
                infrastructureModelToChange.CollectionSystemType = (CollectionSystemTypeEnum)tempInt;
            }

            double.TryParse(fc["DesignFlow_m3_day"], out DesignFlow_m3_day);
            if (DesignFlow_m3_day == 0.0D)
                infrastructureModelToChange.DesignFlow_m3_day = null;
            else
                infrastructureModelToChange.DesignFlow_m3_day = DesignFlow_m3_day;

            double.TryParse(fc["AverageFlow_m3_day"], out AverageFlow_m3_day);
            if (AverageFlow_m3_day == 0.0D)
                infrastructureModelToChange.AverageFlow_m3_day = null;
            else
                infrastructureModelToChange.AverageFlow_m3_day = AverageFlow_m3_day;

            double.TryParse(fc["PeakFlow_m3_day"], out PeakFlow_m3_day);
            if (PeakFlow_m3_day == 0.0D)
                infrastructureModelToChange.PeakFlow_m3_day = null;
            else
                infrastructureModelToChange.PeakFlow_m3_day = PeakFlow_m3_day;

            int.TryParse(fc["PopServed"], out PopServed);
            if (PopServed == 0)
                infrastructureModelToChange.PopServed = null;
            else
                infrastructureModelToChange.PopServed = PopServed;

            if (string.IsNullOrWhiteSpace(fc["AlarmSystemType"]))
                infrastructureModelToChange.AlarmSystemType = null;
            else
            {
                int.TryParse(fc["AlarmSystemType"], out tempInt);
                infrastructureModelToChange.AlarmSystemType = (AlarmSystemTypeEnum)tempInt;
            }

            if (fc["Overflow"] == "0")
                infrastructureModelToChange.CanOverflow = false;
            else
                infrastructureModelToChange.CanOverflow = true;

            double.TryParse(fc["PercFlowOfTotal"], out PercFlowOfTotal);
            if (PercFlowOfTotal == 0.0D)
                infrastructureModelToChange.PercFlowOfTotal = null;
            else
                infrastructureModelToChange.PercFlowOfTotal = PercFlowOfTotal;

            if (string.IsNullOrEmpty(fc["Comments"]))
                infrastructureModelToChange.Comment = "";
            else
                infrastructureModelToChange.Comment = fc["Comments"];

            double.TryParse(fc["AverageDepth_m"], out AverageDepth_m);
            if (AverageDepth_m == 0.0D)
                infrastructureModelToChange.AverageDepth_m = null;
            else
                infrastructureModelToChange.AverageDepth_m = AverageDepth_m;

            int.TryParse(fc["NumberOfPorts"], out NumberOfPorts);
            if (NumberOfPorts == 0.0D)
                infrastructureModelToChange.NumberOfPorts = null;
            else
                infrastructureModelToChange.NumberOfPorts = NumberOfPorts;

            double.TryParse(fc["PortDiameter_m"], out PortDiameter_m);
            if (PortDiameter_m == 0.0D)
                infrastructureModelToChange.PortDiameter_m = null;
            else
                infrastructureModelToChange.PortDiameter_m = PortDiameter_m;

            double.TryParse(fc["PortSpacing_m"], out PortSpacing_m);
            if (PortSpacing_m == 0.0D)
                infrastructureModelToChange.PortSpacing_m = null;
            else
                infrastructureModelToChange.PortSpacing_m = PortSpacing_m;

            double.TryParse(fc["PortElevation_m"], out PortElevation_m);
            if (PortElevation_m == 0.0D)
                infrastructureModelToChange.PortElevation_m = null;
            else
                infrastructureModelToChange.PortElevation_m = PortElevation_m;

            double.TryParse(fc["VerticalAngle_deg"], out VerticalAngle_deg);
            if (VerticalAngle_deg == 0.0D)
                infrastructureModelToChange.VerticalAngle_deg = null;
            else
                infrastructureModelToChange.VerticalAngle_deg = VerticalAngle_deg;

            double.TryParse(fc["HorizontalAngle_deg"], out HorizontalAngle_deg);
            if (HorizontalAngle_deg == 0.0D)
                infrastructureModelToChange.HorizontalAngle_deg = null;
            else
                infrastructureModelToChange.HorizontalAngle_deg = HorizontalAngle_deg;

            double.TryParse(fc["DecayRate_per_day"], out DecayRate_per_day);
            if (DecayRate_per_day == 0.0D)
                infrastructureModelToChange.DecayRate_per_day = null;
            else
                infrastructureModelToChange.DecayRate_per_day = DecayRate_per_day;

            double.TryParse(fc["NearFieldVelocity_m_s"], out NearFieldVelocity_m_s);
            if (NearFieldVelocity_m_s == 0.0D)
                infrastructureModelToChange.NearFieldVelocity_m_s = null;
            else
                infrastructureModelToChange.NearFieldVelocity_m_s = NearFieldVelocity_m_s;

            double.TryParse(fc["FarFieldVelocity_m_s"], out FarFieldVelocity_m_s);
            if (FarFieldVelocity_m_s == 0.0D)
                infrastructureModelToChange.FarFieldVelocity_m_s = null;
            else
                infrastructureModelToChange.FarFieldVelocity_m_s = FarFieldVelocity_m_s;

            double.TryParse(fc["ReceivingWaterSalinity_PSU"], out ReceivingWaterSalinity_PSU);
            if (ReceivingWaterSalinity_PSU == 0.0D)
                infrastructureModelToChange.ReceivingWaterSalinity_PSU = null;
            else
                infrastructureModelToChange.ReceivingWaterSalinity_PSU = ReceivingWaterSalinity_PSU;

            double.TryParse(fc["ReceivingWaterTemperature_C"], out ReceivingWaterTemperature_C);
            if (ReceivingWaterTemperature_C == 0.0D)
                infrastructureModelToChange.ReceivingWaterTemperature_C = null;
            else
                infrastructureModelToChange.ReceivingWaterTemperature_C = ReceivingWaterTemperature_C;

            int.TryParse(fc["ReceivingWater_MPN_per_100ml"], out ReceivingWater_MPN_per_100ml);
            if (ReceivingWater_MPN_per_100ml == 0)
                infrastructureModelToChange.ReceivingWater_MPN_per_100ml = null;
            else
                infrastructureModelToChange.ReceivingWater_MPN_per_100ml = ReceivingWater_MPN_per_100ml;

            double.TryParse(fc["DistanceFromShore_m"], out DistanceFromShore_m);
            if (DistanceFromShore_m == 0.0D)
                infrastructureModelToChange.DistanceFromShore_m = null;
            else
                infrastructureModelToChange.DistanceFromShore_m = DistanceFromShore_m;


            double.TryParse(fc["Lat"], out Lat);
            if (Lat == 0.0D)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));

            double.TryParse(fc["Lng"], out Lng);
            if (Lng == 0.0D)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));

            if (!string.IsNullOrWhiteSpace(fc["LatOutfall"]))
            {
                LatOutfall = double.Parse(fc["LatOutfall"]);
            }
            if (!string.IsNullOrWhiteSpace(fc["LngOutfall"]))
            {
                LngOutfall = double.Parse(fc["LngOutfall"]);
            }

            TVTypeEnum tvType = TVTypeEnum.Error;
            if (infrastructureModelToChange.InfrastructureType == InfrastructureTypeEnum.WWTP)
            {
                tvType = TVTypeEnum.WasteWaterTreatmentPlant;
            }
            else if (infrastructureModelToChange.InfrastructureType == InfrastructureTypeEnum.LiftStation)
            {
                tvType = TVTypeEnum.LiftStation;
            }
            else if (infrastructureModelToChange.InfrastructureType == InfrastructureTypeEnum.Other)
            {
                tvType = TVTypeEnum.OtherInfrastructure;
            }
            else if (infrastructureModelToChange.InfrastructureType == InfrastructureTypeEnum.SeeOtherMunicipality)
            {
                tvType = TVTypeEnum.SeeOtherMunicipality;
            }
            else if (infrastructureModelToChange.InfrastructureType == InfrastructureTypeEnum.LineOverflow)
            {
                tvType = TVTypeEnum.LineOverflow;
            }

            InfrastructureModel infrastructureModelRet2 = InfrastructureCoordinateUpdateDB(infrastructureModelToChange, tvType, (float)Lat, (float)Lng, (float?)LatOutfall, (float?)LngOutfall);
            if (!string.IsNullOrWhiteSpace(infrastructureModelRet2.Error))
                return ReturnError(infrastructureModelRet2.Error);

            InfrastructureModel infrastructureModelRet = PostUpdateInfrastructureDB(infrastructureModelToChange);
            if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                return ReturnError(infrastructureModelRet.Error);

            return infrastructureModelRet;
        }
        public InfrastructureModel PostAddInfrastructureDB(InfrastructureModel infrastructureModel)
        {
            string retStr = InfrastructureModelOK(infrastructureModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(infrastructureModel.InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            Infrastructure infrastructureNew = new Infrastructure();
            infrastructureNew.InfrastructureTVItemID = infrastructureModel.InfrastructureTVItemID;
            retStr = FillInfrastructure(infrastructureNew, infrastructureModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Infrastructures.Add(infrastructureNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Infrastructures", infrastructureNew.InfrastructureID, LogCommandEnum.Add, infrastructureNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    InfrastructureLanguageModel infrastructureLanguageModelNew = new InfrastructureLanguageModel()
                    {
                        InfrastructureID = infrastructureNew.InfrastructureID,
                        Comment = infrastructureModel.Comment,
                        Language = Lang,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    if (infrastructureLanguageModelNew.Comment == null)
                    {
                        infrastructureLanguageModelNew.Comment = ServiceRes.Empty;
                    }

                    InfrastructureLanguageModel infrastructureLanguageModelRet = _InfrastructureLanguageService.PostAddInfrastructureLanguageDB(infrastructureLanguageModelNew);
                    if (!string.IsNullOrEmpty(infrastructureLanguageModelRet.Error))
                        return ReturnError(infrastructureLanguageModelRet.Error);
                }

                ts.Complete();
            }

            return GetInfrastructureModelWithInfrastructureIDDB(infrastructureNew.InfrastructureID);

        }
        public InfrastructureModel PostDeleteInfrastructureDB(int InfrastructureID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Infrastructure InfrastructureToDelete = GetInfrastructureWithInfrastructureIDDB(InfrastructureID);
            if (InfrastructureToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Infrastructure));

            int TVItemIDToDelete = InfrastructureToDelete.InfrastructureTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.Infrastructures.Remove(InfrastructureToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Infrastructures", InfrastructureToDelete.InfrastructureID, LogCommandEnum.Delete, InfrastructureToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(InfrastructureToDelete.InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                    return ReturnError(mapInfoModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public InfrastructureModel PostDeleteInfrastructureWithInfrastructureTVItemIDDB(int InfrastructureTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                return ReturnError(infrastructureModel.Error);

            List<TVItemLinkModel> tvItemLinkModelList = _TVItemLinkService.GetTVItemLinkModelListWithToTVItemIDDB(InfrastructureTVItemID);
            if (tvItemLinkModelList.Count > 0)
                return ReturnError(string.Format(ServiceRes._HasChildItems, ServiceRes.Infrastructure));

            using (TransactionScope ts = new TransactionScope())
            {
                TVItemLinkModel tvItemLinkModel = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDB(InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    return ReturnError(tvItemLinkModel.Error);

                infrastructureModel = PostDeleteInfrastructureDB(infrastructureModel.InfrastructureID);
                if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                    return ReturnError(infrastructureModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public InfrastructureModel PostUpdateInfrastructureDB(InfrastructureModel infrastructureModel)
        {
            string retStr = InfrastructureModelOK(infrastructureModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Infrastructure infrastructureToUpdate = GetInfrastructureWithInfrastructureIDDB(infrastructureModel.InfrastructureID);
            if (infrastructureToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Infrastructure));

            retStr = FillInfrastructure(infrastructureToUpdate, infrastructureModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Infrastructures", infrastructureToUpdate.InfrastructureID, LogCommandEnum.Change, infrastructureToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(infrastructureToUpdate.InfrastructureTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(tvItemLanguageModelToUpdate.Error);

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(infrastructureModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        InfrastructureLanguageModel infrastructureLanguageModel = new InfrastructureLanguageModel()
                        {
                            InfrastructureID = infrastructureToUpdate.InfrastructureID,
                            Comment = infrastructureModel.Comment,
                            Language = Lang,
                            TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        };

                        if (infrastructureLanguageModel.Comment == null)
                        {
                            infrastructureLanguageModel.Comment = ServiceRes.Empty;
                        }

                        InfrastructureLanguageModel infrastructureLanguageModelRet = _InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModel);
                        if (!string.IsNullOrEmpty(infrastructureLanguageModelRet.Error))
                            return ReturnError(infrastructureLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }

            return GetInfrastructureModelWithInfrastructureIDDB(infrastructureModel.InfrastructureID);
        }
        public string SetInfrastructureChildParentDB(int ChildTVItemID, int ParentTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return contactOK.Error;

            if (ChildTVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.FromTVItemID);

            if (ParentTVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.ToTVItemID);

            TVItemModel tvItemModelFromExist = _TVItemService.GetTVItemModelWithTVItemIDDB(ChildTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelFromExist.Error))
                return tvItemModelFromExist.Error;

            TVItemModel tvItemModelToExist = new TVItemModel();
            if (ParentTVItemID != -1) // Should move to top
            {
                tvItemModelToExist = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelToExist.Error))
                    return tvItemModelToExist.Error;
            }

            using (TransactionScope ts = new TransactionScope())
            {
                TVItemLinkModel tvItemLinkModelRet = new TVItemLinkModel();
                if (ParentTVItemID != -1)
                {
                    tvItemLinkModelRet = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(ChildTVItemID, ParentTVItemID);
                    // Not a problem if you can't delete, it might not exist
                    //if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                    //    return tvItemLinkModelRet.Error;
                }

                tvItemLinkModelRet = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndFromTVTypeAndToTVTypeDB(ChildTVItemID, TVTypeEnum.Infrastructure, TVTypeEnum.Infrastructure);

                if (ParentTVItemID != -1)
                {
                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = ChildTVItemID,
                        ToTVItemID = ParentTVItemID,
                        FromTVType = tvItemModelFromExist.TVType,
                        ToTVType = tvItemModelToExist.TVType,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + ChildTVItemID + "p" + ParentTVItemID,
                        StartDateTime_Local = DateTime.UtcNow,
                        EndDateTime_Local = DateTime.UtcNow,
                        ParentTVItemLinkID = null,
                    };

                    TVItemLinkModel tvItemLinkModelRet2 = _TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet2.Error))
                        return tvItemLinkModelRet2.Error;
                }

                ts.Complete();
            }

            List<TVItemModel> TVItemModelInfrastructureList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelFromExist.ParentID, TVTypeEnum.Infrastructure);

            foreach (TVItemModel tvItemModel in TVItemModelInfrastructureList)
            {
                InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModel.TVItemID);
                if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                    return infrastructureModel.Error;

                TVTypeEnum tvType = TVTypeEnum.Error;
                switch (infrastructureModel.InfrastructureType)
                {
                    case InfrastructureTypeEnum.LiftStation:
                        {
                            tvType = TVTypeEnum.LiftStation;
                        }
                        break;
                    case InfrastructureTypeEnum.LineOverflow:
                        {
                            tvType = TVTypeEnum.LineOverflow;
                        }
                        break;
                    case InfrastructureTypeEnum.Other:
                        {
                            tvType = TVTypeEnum.OtherInfrastructure;
                        }
                        break;
                    case InfrastructureTypeEnum.SeeOtherMunicipality:
                        {
                            tvType = TVTypeEnum.SeeOtherMunicipality;
                        }
                        break;
                    case InfrastructureTypeEnum.WWTP:
                        {
                            tvType = TVTypeEnum.WasteWaterTreatmentPlant;
                        }
                        break;
                    default:
                        break;
                }

                float Lat = 0.0f;
                float Lng = 0.0f;
                float? LatOutfall = null;
                float? LngOutfall = null;

                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModel.InfrastructureTVItemID, tvType, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    Lat = (float)mapInfoPointModelList[0].Lat;
                    Lng = (float)mapInfoPointModelList[0].Lng;

                    List<MapInfoPointModel> mapInfoPointModelListOutfall = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModel.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelListOutfall.Count > 0)
                    {
                        LatOutfall = (float)mapInfoPointModelListOutfall[0].Lat;
                        LngOutfall = (float)mapInfoPointModelListOutfall[0].Lng;
                    }
                    InfrastructureModel infrastructureModelRet2 = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)Lat, (float)Lng, (float?)LatOutfall, (float?)LngOutfall);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelRet2.Error))
                        return infrastructureModelRet2.Error;

                    InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)Lat, (float)Lng);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                        return infrastructureModelRet3.Error;
                }
            }

            return "";
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
