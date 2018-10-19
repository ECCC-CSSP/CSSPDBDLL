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
    public partial class ReportServiceVisual_Plumes_Scenario_Result : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceVisual_Plumes_Scenario_Result(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportVisual_Plumes_Scenario_ResultModel> GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID /* which is really VPScenarioID*/, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelList = new List<ReportVisual_Plumes_Scenario_ResultModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Visual_Plumes_Scenario_Result";
            int Counter = 0;
            IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Visual_Plumes_Scenario")
                return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Visual_Plumes_Scenario", ParentTagItem) } };

            VPScenario vpScenario = (from c in db.VPScenarios
                                     where c.VPScenarioID == UnderTVItemID
                                     select c).FirstOrDefault();

            if (vpScenario == null)
                return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.VPScenarioID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportVisual_Plumes_Scenario_ResultModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Error = retStr } };

            reportVisual_Plumes_Scenario_ResultModelQ =
            (from c in db.VPResults
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == c.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where c.VPScenarioID == UnderTVItemID
             select new ReportVisual_Plumes_Scenario_ResultModel
             {
                 Visual_Plumes_Scenario_Result_Error = "",
                 Visual_Plumes_Scenario_Result_Counter = 1,
                 Visual_Plumes_Scenario_Result_ID = c.VPScenarioID,
                 Visual_Plumes_Scenario_Result_Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                 Visual_Plumes_Scenario_Result_Dilution = (float)c.Dilution,
                 Visual_Plumes_Scenario_Result_Dispersion_Distance_m = (float)c.DispersionDistance_m,
                 Visual_Plumes_Scenario_Result_Far_Field_Width_m = (float)c.FarFieldWidth_m,
                 Visual_Plumes_Scenario_Result_Ordinal = c.Ordinal,
                 Visual_Plumes_Scenario_Result_Travel_Time_hour = (float)c.TravelTime_hour,
                 Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC = c.LastUpdateDate_UTC,
                 Visual_Plumes_Scenario_Result_Last_Update_Contact_Name = contact.contactName,
                 Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Error = retStr } };

                if (CountOnly)
                    return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Counter = reportVisual_Plumes_Scenario_ResultModelQ.Count() } };

                reportVisual_Plumes_Scenario_ResultModelList = reportVisual_Plumes_Scenario_ResultModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportVisual_Plumes_Scenario_ResultModel>() { new ReportVisual_Plumes_Scenario_ResultModel() { Visual_Plumes_Scenario_Result_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportVisual_Plumes_Scenario_ResultModel reportVisual_Plumes_Scenario_ResultModel in reportVisual_Plumes_Scenario_ResultModelList)
            {
                Counter += 1;
                reportVisual_Plumes_Scenario_ResultModel.Visual_Plumes_Scenario_Result_Counter = Counter;
            }

            return reportVisual_Plumes_Scenario_ResultModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}