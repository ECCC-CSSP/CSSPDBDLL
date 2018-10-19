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
    public partial class ReportServiceVisual_Plumes_Scenario_Ambient : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceVisual_Plumes_Scenario_Ambient(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportVisual_Plumes_Scenario_AmbientModel> GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID /* which is really VPScenarioID*/, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelList = new List<ReportVisual_Plumes_Scenario_AmbientModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Visual_Plumes_Scenario_Ambient";
            int Counter = 0;
            IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Visual_Plumes_Scenario")
                return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Visual_Plumes_Scenario", ParentTagItem) } };

            VPScenario vpScenario = (from c in db.VPScenarios
                                     where c.VPScenarioID == UnderTVItemID
                                     select c).FirstOrDefault();

            if (vpScenario == null)
                return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.VPScenarioID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportVisual_Plumes_Scenario_AmbientModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Error = retStr } };

            reportVisual_Plumes_Scenario_AmbientModelQ =
            (from c in db.VPAmbients
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == c.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where c.VPScenarioID == UnderTVItemID
             select new ReportVisual_Plumes_Scenario_AmbientModel
             {
                 Visual_Plumes_Scenario_Ambient_Error = "",
                 Visual_Plumes_Scenario_Ambient_Counter = 1,
                 Visual_Plumes_Scenario_Ambient_ID = c.VPScenarioID,
                 Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU = (float)c.AmbientSalinity_PSU,
                 Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C = (float)c.AmbientTemperature_C,
                 Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                 Visual_Plumes_Scenario_Ambient_Current_Direction_deg = (float)c.CurrentDirection_deg,
                 Visual_Plumes_Scenario_Ambient_Current_Speed_m_s = (float)c.CurrentSpeed_m_s,
                 Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg = (float)c.CurrentDirection_deg,
                 Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s = (float)c.FarFieldCurrentSpeed_m_s,
                 Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient = (float)c.FarFieldDiffusionCoefficient,
                 Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC = c.LastUpdateDate_UTC,
                 Visual_Plumes_Scenario_Ambient_Measurement_Depth_m = (float)c.MeasurementDepth_m,
                 Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day = (float)c.PollutantDecayRate_per_day,
                 Visual_Plumes_Scenario_Ambient_Row = c.Row,
                 Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name = contact.contactName,
                 Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Error = retStr } };

                if (CountOnly)
                    return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Counter = reportVisual_Plumes_Scenario_AmbientModelQ.Count() } };

                reportVisual_Plumes_Scenario_AmbientModelList = reportVisual_Plumes_Scenario_AmbientModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportVisual_Plumes_Scenario_AmbientModel>() { new ReportVisual_Plumes_Scenario_AmbientModel() { Visual_Plumes_Scenario_Ambient_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportVisual_Plumes_Scenario_AmbientModel reportVisual_Plumes_Scenario_AmbientModel in reportVisual_Plumes_Scenario_AmbientModelList)
            {
                Counter += 1;
                reportVisual_Plumes_Scenario_AmbientModel.Visual_Plumes_Scenario_Ambient_Counter = Counter;
            }

            return reportVisual_Plumes_Scenario_AmbientModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}