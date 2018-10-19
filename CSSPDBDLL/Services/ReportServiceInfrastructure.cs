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
using System.Threading;
using System.Globalization;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using System.IO;
using System.Reflection;
using CSSPReportWriterHelperDLL.Services;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public partial class ReportServiceInfrastructure : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceInfrastructure(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportInfrastructureModel> GetReportInfrastructureModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportInfrastructureModel> reportInfrastructureModelList = new List<ReportInfrastructureModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Infrastructure";
            int Counter = 0;
            IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                    return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Infrastructure.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportInfrastructureModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Infrastructure)
            {
                reportInfrastructureModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from inf in db.Infrastructures
                 from infl in db.InfrastructureLanguages
                 let addr = (from c in db.Addresses
                             let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let mip = (from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where mi.MapInfoID == mip.MapInfoID
                                        && mi.TVItemID == c.AddressTVItemID
                                        && mi.TVType == (int)TVTypeEnum.Address
                                        && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                        select mip).FirstOrDefault()
                             where c.AddressTVItemID == inf.CivicAddressTVItemID
                             select new AddressModel
                             {
                                 Error = "",
                                 AddressID = c.AddressID,
                                 AddressTVItemID = c.AddressTVItemID,
                                 AddressTVText = "",
                                 AddressType = (AddressTypeEnum)c.AddressType,
                                 AddressTypeText = "",
                                 MunicipalityTVItemID = c.MunicipalityTVItemID,
                                 MunicipalityTVText = muni,
                                 ProvinceTVItemID = c.ProvinceTVItemID,
                                 ProvinceTVText = prov,
                                 CountryTVItemID = c.CountryTVItemID,
                                 CountryTVText = country,
                                 StreetName = c.StreetName,
                                 StreetNumber = c.StreetNumber,
                                 StreetType = (StreetTypeEnum)c.StreetType,
                                 StreetTypeText = "",
                                 PostalCode = c.PostalCode,
                                 GoogleAddressText = c.GoogleAddressText,
                                 LatLngText = mip.Lat + " " + mip.Lng,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                             }).FirstOrDefault<AddressModel>()
                 let mpInf = (from m in db.MapInfos
                              from mp in db.MapInfoPoints
                              where m.MapInfoID == mp.MapInfoID
                              && m.TVItemID == c.TVItemID
                              && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                              && (m.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant
                              || m.TVType == (int)TVTypeEnum.LiftStation
                              || m.TVType == (int)TVTypeEnum.LineOverflow)
                              select mp).FirstOrDefault()
                 let mpOut = (from m in db.MapInfos
                              from mp in db.MapInfoPoints
                              where m.MapInfoID == mp.MapInfoID
                              && m.TVItemID == c.TVItemID
                              && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                              && m.TVType == (int)TVTypeEnum.Outfall
                              select mp).FirstOrDefault()
                 let stat = (from s in db.TVItemStats
                             where s.TVItemID == c.TVItemID
                             select s)
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactComment = (from cc in db.Contacts
                                       let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                       let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                       where cc.ContactTVItemID == infl.LastUpdateContactTVItemID
                                       select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                              && c.TVItemID == inf.InfrastructureTVItemID
                              && inf.InfrastructureID == infl.InfrastructureID
                              && infl.Language == (int)Language
                              && c.TVType == (int)TVTypeEnum.Infrastructure
                              && cl.Language == (int)Language
                              && c.TVItemID == UnderTVItemID
                 select new ReportInfrastructureModel
                 {
                     Infrastructure_Error = "",
                     Infrastructure_Counter = 0,
                     Infrastructure_ID = c.TVItemID,
                     Infrastructure_Is_Active = c.IsActive,
                     Infrastructure_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Infrastructure_Lat = (mpInf == null ? 0.0f : (float)mpInf.Lat),
                     Infrastructure_Lng = (mpInf == null ? 0.0f : (float)mpInf.Lng),
                     Infrastructure_Name = cl.TVText,
                     Infrastructure_Name_Translation_Status = (TranslationStatusEnum?)cl.TranslationStatus,
                     Infrastructure_Last_Update_Contact_Name = contact.contactName,
                     Infrastructure_Last_Update_Contact_Initial = contact.contactInitial,
                     Infrastructure_Last_Update_Date_UTC = cl.LastUpdateDate_UTC,
                     Infrastructure_Aeration_Type = (AerationTypeEnum?)inf.AerationType,
                     Infrastructure_Alarm_System_Type = (AlarmSystemTypeEnum?)inf.AlarmSystemType,
                     Infrastructure_Average_Depth_m = (float?)inf.AverageDepth_m,
                     Infrastructure_Average_Flow_m3_day = (float?)inf.AverageFlow_m3_day,
                     Infrastructure_Can_Overflow = inf.CanOverflow ?? false,
                     Infrastructure_Collection_System_Type = (CollectionSystemTypeEnum?)inf.CollectionSystemType,
                     Infrastructure_Comment = infl.Comment,
                     Infrastructure_Comment_Last_Update_Contact_Name = contactComment.contactName,
                     Infrastructure_Comment_Last_Update_Contact_Initial = contactComment.contactInitial,
                     Infrastructure_Comment_Last_Update_Date_UTC = infl.LastUpdateDate_UTC,
                     Infrastructure_Comment_Translation_Status = (TranslationStatusEnum?)infl.TranslationStatus,
                     Infrastructure_Decay_Rate_per_day = (float?)inf.DecayRate_per_day,
                     Infrastructure_Design_Flow_m3_day = (float?)inf.DesignFlow_m3_day,
                     Infrastructure_Disinfection_Type = (DisinfectionTypeEnum?)inf.DisinfectionType,
                     Infrastructure_Distance_From_Shore_m = (float?)inf.DistanceFromShore_m,
                     Infrastructure_Facility_Type = (FacilityTypeEnum)inf.FacilityType,
                     Infrastructure_Far_Field_Velocity_m_s = (float?)inf.FarFieldVelocity_m_s,
                     Infrastructure_Horizontal_Angle_deg = (float?)inf.HorizontalAngle_deg,
                     Infrastructure_Infrastructure_Category = inf.InfrastructureCategory,
                     Infrastructure_Infrastructure_Type = (InfrastructureTypeEnum?)inf.InfrastructureType,
                     Infrastructure_Is_Mechanically_Aerated = (bool?)inf.IsMechanicallyAerated,
                     Infrastructure_LSID = inf.LSID,
                     Infrastructure_Near_Field_Velocity_m_s = (float?)inf.NearFieldVelocity_m_s,
                     Infrastructure_Number_Of_Aerated_Cells = inf.NumberOfAeratedCells,
                     Infrastructure_Number_Of_Cells = inf.NumberOfCells,
                     Infrastructure_Number_Of_Ports = inf.NumberOfPorts,
                     Infrastructure_Outfall_Lat = (mpOut == null ? 0.0f : (float)mpOut.Lat),
                     Infrastructure_Outfall_Lng = (mpOut == null ? 0.0f : (float)mpOut.Lng),
                     Infrastructure_Peak_Flow_m3_day = (float?)inf.PeakFlow_m3_day,
                     Infrastructure_Perc_Flow_Of_Total = (float?)inf.PercFlowOfTotal,
                     Infrastructure_Pop_Served = (int?)inf.PopServed,
                     Infrastructure_Port_Diameter_m = (float?)inf.PortDiameter_m,
                     Infrastructure_Port_Elevation_m = (float?)inf.PortElevation_m,
                     Infrastructure_Port_Spacing_m = (float?)inf.PortSpacing_m,
                     Infrastructure_Preliminary_Treatment_Type = (PreliminaryTreatmentTypeEnum?)inf.PreliminaryTreatmentType,
                     Infrastructure_Primary_Treatment_Type = (PrimaryTreatmentTypeEnum?)inf.PrimaryTreatmentType,
                     Infrastructure_Prism_ID = inf.PrismID,
                     Infrastructure_Receiving_Water_MPN_per_100_ml = inf.ReceivingWater_MPN_per_100ml,
                     Infrastructure_Receiving_Water_Salinity_PSU = (float?)inf.ReceivingWaterSalinity_PSU,
                     Infrastructure_Receiving_Water_Temperature_C = (float?)inf.ReceivingWaterTemperature_C,
                     Infrastructure_Secondary_Treatment_Type = (SecondaryTreatmentTypeEnum?)inf.SecondaryTreatmentType,
                     Infrastructure_See_Other_ID = inf.SeeOtherTVItemID,
                     Infrastructure_Site = inf.Site,
                     Infrastructure_Site_ID = inf.SiteID,
                     Infrastructure_Temp_Catch_All_Remove_Later = inf.TempCatchAllRemoveLater,
                     Infrastructure_Tertiary_Treatment_Type = (TertiaryTreatmentTypeEnum?)inf.TertiaryTreatmentType,
                     Infrastructure_Time_Offset_hour = (float?)inf.TimeOffset_hour,
                     Infrastructure_TPID = inf.TPID,
                     Infrastructure_Treatment_Type = (TreatmentTypeEnum?)inf.TreatmentType,
                     Infrastructure_Vertical_Angle_deg = (float?)inf.VerticalAngle_deg,
                     Infrastructure_Stat_Box_Model_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.BoxModel select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Infrastructure_Stat_Visual_Plumes_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.VisualPlumesScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Infrastructure_Civic_Address = (addr == null ? ServiceRes.Empty : (Language == LanguageEnum.fr
                     ? addr.StreetNumber + " " + addr.StreetName + " " + addr.StreetTypeText +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode : addr.StreetNumber + " " + addr.StreetTypeText + " " + addr.StreetName +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode)),
                     Infrastructure_Google_Address = (addr == null ? ServiceRes.Empty : addr.GoogleAddressText),
                 });
            }
            else
            {
                reportInfrastructureModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from inf in db.Infrastructures
                 from infl in db.InfrastructureLanguages
                 let addr = (from c in db.Addresses
                             let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let mip = (from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where mi.MapInfoID == mip.MapInfoID
                                        && mi.TVItemID == c.AddressTVItemID
                                        && mi.TVType == (int)TVTypeEnum.Address
                                        && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                        select mip).FirstOrDefault()
                             where c.AddressTVItemID == inf.CivicAddressTVItemID
                             select new AddressModel
                             {
                                 Error = "",
                                 AddressID = c.AddressID,
                                 AddressTVItemID = c.AddressTVItemID,
                                 AddressTVText = "",
                                 AddressType = (AddressTypeEnum)c.AddressType,
                                 AddressTypeText = "",
                                 MunicipalityTVItemID = c.MunicipalityTVItemID,
                                 MunicipalityTVText = muni,
                                 ProvinceTVItemID = c.ProvinceTVItemID,
                                 ProvinceTVText = prov,
                                 CountryTVItemID = c.CountryTVItemID,
                                 CountryTVText = country,
                                 StreetName = c.StreetName,
                                 StreetNumber = c.StreetNumber,
                                 StreetType = (StreetTypeEnum)c.StreetType,
                                 StreetTypeText = "",
                                 PostalCode = c.PostalCode,
                                 GoogleAddressText = c.GoogleAddressText,
                                 LatLngText = mip.Lat + " " + mip.Lng,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                             }).FirstOrDefault<AddressModel>()
                 let mpInf = (from m in db.MapInfos
                              from mp in db.MapInfoPoints
                              where m.MapInfoID == mp.MapInfoID
                              && m.TVItemID == c.TVItemID
                              && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                              && (m.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant
                              || m.TVType == (int)TVTypeEnum.LiftStation
                              || m.TVType == (int)TVTypeEnum.LineOverflow)
                              select mp).FirstOrDefault()
                 let mpOut = (from m in db.MapInfos
                              from mp in db.MapInfoPoints
                              where m.MapInfoID == mp.MapInfoID
                              && m.TVItemID == c.TVItemID
                              && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                              && m.TVType == (int)TVTypeEnum.Outfall
                              select mp).FirstOrDefault()
                 let stat = (from s in db.TVItemStats
                             where s.TVItemID == c.TVItemID
                             select s)
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactComment = (from cc in db.Contacts
                                       let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                       let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                       where cc.ContactTVItemID == infl.LastUpdateContactTVItemID
                                       select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == inf.InfrastructureTVItemID
                 && inf.InfrastructureID == infl.InfrastructureID
                 && infl.Language == (int)Language
                 && c.TVType == (int)TVTypeEnum.Infrastructure
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportInfrastructureModel
                 {
                     Infrastructure_Error = "",
                     Infrastructure_Counter = 0,
                     Infrastructure_ID = c.TVItemID,
                     Infrastructure_Is_Active = c.IsActive,
                     Infrastructure_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Infrastructure_Lat = (mpInf == null ? 0.0f : (float)mpInf.Lat),
                     Infrastructure_Lng = (mpInf == null ? 0.0f : (float)mpInf.Lng),
                     Infrastructure_Name = cl.TVText,
                     Infrastructure_Name_Translation_Status = (TranslationStatusEnum?)cl.TranslationStatus,
                     Infrastructure_Last_Update_Contact_Name = contact.contactName,
                     Infrastructure_Last_Update_Contact_Initial = contact.contactInitial,
                     Infrastructure_Last_Update_Date_UTC = cl.LastUpdateDate_UTC,
                     Infrastructure_Aeration_Type = (AerationTypeEnum?)inf.AerationType,
                     Infrastructure_Alarm_System_Type = (AlarmSystemTypeEnum?)inf.AlarmSystemType,
                     Infrastructure_Average_Depth_m = (float?)inf.AverageDepth_m,
                     Infrastructure_Average_Flow_m3_day = (float?)inf.AverageFlow_m3_day,
                     Infrastructure_Can_Overflow = inf.CanOverflow ?? false,
                     Infrastructure_Collection_System_Type = (CollectionSystemTypeEnum?)inf.CollectionSystemType,
                     Infrastructure_Comment = infl.Comment,
                     Infrastructure_Comment_Last_Update_Contact_Name = contactComment.contactName,
                     Infrastructure_Comment_Last_Update_Contact_Initial = contactComment.contactInitial,
                     Infrastructure_Comment_Last_Update_Date_UTC = infl.LastUpdateDate_UTC,
                     Infrastructure_Comment_Translation_Status = (TranslationStatusEnum?)infl.TranslationStatus,
                     Infrastructure_Decay_Rate_per_day = (float?)inf.DecayRate_per_day,
                     Infrastructure_Design_Flow_m3_day = (float?)inf.DesignFlow_m3_day,
                     Infrastructure_Disinfection_Type = (DisinfectionTypeEnum?)inf.DisinfectionType,
                     Infrastructure_Distance_From_Shore_m = (float?)inf.DistanceFromShore_m,
                     Infrastructure_Facility_Type = (FacilityTypeEnum?)inf.FacilityType,
                     Infrastructure_Far_Field_Velocity_m_s = (float?)inf.FarFieldVelocity_m_s,
                     Infrastructure_Horizontal_Angle_deg = (float?)inf.HorizontalAngle_deg,
                     Infrastructure_Infrastructure_Category = inf.InfrastructureCategory,
                     Infrastructure_Infrastructure_Type = (InfrastructureTypeEnum?)inf.InfrastructureType,
                     Infrastructure_Is_Mechanically_Aerated = (bool?)inf.IsMechanicallyAerated,
                     Infrastructure_LSID = inf.LSID,
                     Infrastructure_Near_Field_Velocity_m_s = (float?)inf.NearFieldVelocity_m_s,
                     Infrastructure_Number_Of_Aerated_Cells = inf.NumberOfAeratedCells,
                     Infrastructure_Number_Of_Cells = inf.NumberOfCells,
                     Infrastructure_Number_Of_Ports = inf.NumberOfPorts,
                     Infrastructure_Outfall_Lat = (mpOut == null ? 0.0f : (float)mpOut.Lat),
                     Infrastructure_Outfall_Lng = (mpOut == null ? 0.0f : (float)mpOut.Lng),
                     Infrastructure_Peak_Flow_m3_day = (float?)inf.PeakFlow_m3_day,
                     Infrastructure_Perc_Flow_Of_Total = (float?)inf.PercFlowOfTotal,
                     Infrastructure_Pop_Served = (int?)inf.PopServed,
                     Infrastructure_Port_Diameter_m = (float?)inf.PortDiameter_m,
                     Infrastructure_Port_Elevation_m = (float?)inf.PortElevation_m,
                     Infrastructure_Port_Spacing_m = (float?)inf.PortSpacing_m,
                     Infrastructure_Preliminary_Treatment_Type = (PreliminaryTreatmentTypeEnum?)inf.PreliminaryTreatmentType,
                     Infrastructure_Primary_Treatment_Type = (PrimaryTreatmentTypeEnum?)inf.PrimaryTreatmentType,
                     Infrastructure_Prism_ID = inf.PrismID,
                     Infrastructure_Receiving_Water_MPN_per_100_ml = inf.ReceivingWater_MPN_per_100ml,
                     Infrastructure_Receiving_Water_Salinity_PSU = (float?)inf.ReceivingWaterSalinity_PSU,
                     Infrastructure_Receiving_Water_Temperature_C = (float?)inf.ReceivingWaterTemperature_C,
                     Infrastructure_Secondary_Treatment_Type = (SecondaryTreatmentTypeEnum?)inf.SecondaryTreatmentType,
                     Infrastructure_See_Other_ID = inf.SeeOtherTVItemID,
                     Infrastructure_Site = inf.Site,
                     Infrastructure_Site_ID = inf.SiteID,
                     Infrastructure_Temp_Catch_All_Remove_Later = inf.TempCatchAllRemoveLater,
                     Infrastructure_Tertiary_Treatment_Type = (TertiaryTreatmentTypeEnum?)inf.TertiaryTreatmentType,
                     Infrastructure_Time_Offset_hour = (float?)inf.TimeOffset_hour,
                     Infrastructure_TPID = inf.TPID,
                     Infrastructure_Treatment_Type = (TreatmentTypeEnum?)inf.TreatmentType,
                     Infrastructure_Vertical_Angle_deg = (float?)inf.VerticalAngle_deg,
                     Infrastructure_Stat_Box_Model_Scenario_Count = 0,
                     Infrastructure_Stat_Visual_Plumes_Scenario_Count = 0,
                     Infrastructure_Civic_Address = (addr == null ? ServiceRes.Empty : (Language == LanguageEnum.fr
                     ? addr.StreetNumber + " " + addr.StreetName + " " + addr.StreetTypeText +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode : addr.StreetNumber + " " + addr.StreetTypeText + " " + addr.StreetName +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode)),
                     Infrastructure_Google_Address = (addr == null ? ServiceRes.Empty : addr.GoogleAddressText),
                 });
            }

            try
            {
                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure(reportInfrastructureModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Error = retStr } };

                if (CountOnly)
                    return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Counter = reportInfrastructureModelQ.Count() } };

                reportInfrastructureModelList = reportInfrastructureModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportInfrastructureModel>() { new ReportInfrastructureModel() { Infrastructure_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportInfrastructureModel reportInfrastructureModel in reportInfrastructureModelList)
            {
                Counter += 1;
                reportInfrastructureModel.Infrastructure_Counter = Counter;
            }

            return reportInfrastructureModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}