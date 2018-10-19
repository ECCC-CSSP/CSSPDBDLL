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
    public partial class ReportServiceVisual_Plumes_Scenario : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceVisual_Plumes_Scenario(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportVisual_Plumes_ScenarioModel> GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            string TagItem = "Visual_Plumes_Scenario";
            List<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelList = new List<ReportVisual_Plumes_ScenarioModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            int Counter = 0;
            IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                    return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportVisual_Plumes_ScenarioModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Infrastructure)
            {
                reportVisual_Plumes_ScenarioModelQ =
                    (from t in db.TVItems
                     from c in db.VPScenarios
                     from cl in db.VPScenarioLanguages
                     let contact = (from cc in db.Contacts
                                    let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                    let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                    where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                    select new { contactName, contactInitial }).FirstOrDefault()
                     where t.TVItemID == c.InfrastructureTVItemID
                     && c.VPScenarioID == cl.VPScenarioID
                     && cl.Language == (int)Language
                     && t.TVType == (int)TVTypeEnum.Infrastructure
                     && t.TVItemID == UnderTVItemID
                     select new ReportVisual_Plumes_ScenarioModel
                     {
                         Visual_Plumes_Scenario_Error = "",
                         Visual_Plumes_Scenario_Counter = 1,
                         Visual_Plumes_Scenario_ID = c.VPScenarioID,
                         Visual_Plumes_Scenario_Acute_Mix_Zone_m = (float)c.AcuteMixZone_m,
                         Visual_Plumes_Scenario_Chronic_Mix_Zone_m = (float)c.ChronicMixZone_m,
                         Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                         Visual_Plumes_Scenario_Effluent_Flow_m3_s = (float)c.EffluentFlow_m3_s,
                         Visual_Plumes_Scenario_Effluent_Salinity_PSU = (float)c.EffluentSalinity_PSU,
                         Visual_Plumes_Scenario_Effluent_Temperature_C = (float)c.EffluentTemperature_C,
                         Visual_Plumes_Scenario_Effluent_Velocity_m_s = (float)c.EffluentVelocity_m_s,
                         Visual_Plumes_Scenario_Froude_Number = (float)c.FroudeNumber,
                         Visual_Plumes_Scenario_Horizontal_Angle_deg = (float)c.HorizontalAngle_deg,
                         Visual_Plumes_Scenario_Name = cl.VPScenarioName,
                         Visual_Plumes_Scenario_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                         Visual_Plumes_Scenario_Number_Of_Ports = c.NumberOfPorts,
                         Visual_Plumes_Scenario_Port_Depth_m = (float)c.PortDepth_m,
                         Visual_Plumes_Scenario_Port_Diameter_m = (float)c.PortDiameter_m,
                         Visual_Plumes_Scenario_Port_Elevation_m = (float)c.PortElevation_m,
                         Visual_Plumes_Scenario_Port_Spacing_m = (float)c.PortSpacing_m,
                         Visual_Plumes_Scenario_Raw_Results = c.RawResults,
                         Visual_Plumes_Scenario_Use_As_Best_Estimate = c.UseAsBestEstimate,
                         Visual_Plumes_Scenario_Vertical_Angle_deg = (float)c.VerticalAngle_deg,
                         Visual_Plumes_Scenario_Last_Update_Contact_Name = contact.contactName,
                         Visual_Plumes_Scenario_Last_Update_Contact_Initial = contact.contactInitial,
                         Visual_Plumes_Scenario_Last_Update_Date_UTC = c.LastUpdateDate_UTC,
                         Visual_Plumes_Scenario_Status = (ScenarioStatusEnum)c.VPScenarioStatus,
                     });
            }
            else
            {
                reportVisual_Plumes_ScenarioModelQ =
                    (from t in db.TVItems
                     from c in db.VPScenarios
                     from cl in db.VPScenarioLanguages
                     let contact = (from cc in db.Contacts
                                    let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                    let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                    where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                    select new { contactName, contactInitial }).FirstOrDefault()
                     where t.TVItemID == c.InfrastructureTVItemID
                     && c.VPScenarioID == cl.VPScenarioID
                     && cl.Language == (int)Language
                     && t.TVType == (int)TVTypeEnum.Infrastructure
                     && t.TVPath.StartsWith(tvItem.TVPath + "p")
                     select new ReportVisual_Plumes_ScenarioModel
                     {
                         Visual_Plumes_Scenario_Error = "",
                         Visual_Plumes_Scenario_Counter = 1,
                         Visual_Plumes_Scenario_ID = c.VPScenarioID,
                         Visual_Plumes_Scenario_Acute_Mix_Zone_m = (float)c.AcuteMixZone_m,
                         Visual_Plumes_Scenario_Chronic_Mix_Zone_m = (float)c.ChronicMixZone_m,
                         Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                         Visual_Plumes_Scenario_Effluent_Flow_m3_s = (float)c.EffluentFlow_m3_s,
                         Visual_Plumes_Scenario_Effluent_Salinity_PSU = (float)c.EffluentSalinity_PSU,
                         Visual_Plumes_Scenario_Effluent_Temperature_C = (float)c.EffluentTemperature_C,
                         Visual_Plumes_Scenario_Effluent_Velocity_m_s = (float)c.EffluentVelocity_m_s,
                         Visual_Plumes_Scenario_Froude_Number = (float)c.FroudeNumber,
                         Visual_Plumes_Scenario_Horizontal_Angle_deg = (float)c.HorizontalAngle_deg,
                         Visual_Plumes_Scenario_Name = cl.VPScenarioName,
                         Visual_Plumes_Scenario_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                         Visual_Plumes_Scenario_Number_Of_Ports = c.NumberOfPorts,
                         Visual_Plumes_Scenario_Port_Depth_m = (float)c.PortDepth_m,
                         Visual_Plumes_Scenario_Port_Diameter_m = (float)c.PortDiameter_m,
                         Visual_Plumes_Scenario_Port_Elevation_m = (float)c.PortElevation_m,
                         Visual_Plumes_Scenario_Port_Spacing_m = (float)c.PortSpacing_m,
                         Visual_Plumes_Scenario_Raw_Results = c.RawResults,
                         Visual_Plumes_Scenario_Use_As_Best_Estimate = c.UseAsBestEstimate,
                         Visual_Plumes_Scenario_Vertical_Angle_deg = (float)c.VerticalAngle_deg,
                         Visual_Plumes_Scenario_Last_Update_Contact_Name = contact.contactName,
                         Visual_Plumes_Scenario_Last_Update_Contact_Initial = contact.contactInitial,
                         Visual_Plumes_Scenario_Last_Update_Date_UTC = c.LastUpdateDate_UTC,
                         Visual_Plumes_Scenario_Status = (ScenarioStatusEnum)c.VPScenarioStatus,
                     });
            }

            try
            {
                reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario(reportVisual_Plumes_ScenarioModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = retStr } };

                if (CountOnly)
                    return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Counter = reportVisual_Plumes_ScenarioModelQ.Count() } };

                reportVisual_Plumes_ScenarioModelList = reportVisual_Plumes_ScenarioModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportVisual_Plumes_ScenarioModel>() { new ReportVisual_Plumes_ScenarioModel() { Visual_Plumes_Scenario_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportVisual_Plumes_ScenarioModel reportVisual_Plumes_ScenarioModel in reportVisual_Plumes_ScenarioModelList)
            {
                Counter += 1;
                reportVisual_Plumes_ScenarioModel.Visual_Plumes_Scenario_Counter = Counter;
            }

            return reportVisual_Plumes_ScenarioModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}