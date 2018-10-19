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
    public partial class ReportServiceSampling_Plan_Lab_Sheet : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSampling_Plan_Lab_Sheet(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSampling_Plan_Lab_SheetModel> GetReportSampling_Plan_Lab_SheetModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelList = new List<ReportSampling_Plan_Lab_SheetModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Sampling_Plan_Lab_Sheet";
            int Counter = 0;
            IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            SamplingPlan SamplingPlan = (from c in db.SamplingPlans
                                 where c.SamplingPlanID == UnderTVItemID
                                 select c).FirstOrDefault();

            if (SamplingPlan == null)
                return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SamplingPlan, ServiceRes.SamplingPlanID, UnderTVItemID.ToString()) } };

            if (ParentTagItem != "Sampling_Plan")
                return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.SamplingPlan.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSampling_Plan_Lab_SheetModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Error = retStr } };

            reportSampling_Plan_Lab_SheetModelQ =
            (from p in db.SamplingPlans
             from s in db.LabSheets
             let province = (from cl in db.TVItemLanguages where cl.TVItemID == p.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault()
             let subsector = (from cl in db.TVItemLanguages
                              where cl.TVItemID == s.SubsectorTVItemID
                              && cl.Language == (int)Language
                              select cl.TVText).FirstOrDefault()
             let planName = (from cl in db.TVItemLanguages
                             where cl.TVItemID == p.SamplingPlanID
                             && cl.Language == (int)Language
                             select cl.TVText).FirstOrDefault()
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             let contactApproved = (from cc in db.Contacts
                                    let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                    let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                    where cc.ContactTVItemID == s.AcceptedOrRejectedByContactTVItemID
                                    select new { contactName, contactInitial }).FirstOrDefault()
             where p.SamplingPlanID == s.SamplingPlanID
             && s.SamplingPlanID == UnderTVItemID
             select new ReportSampling_Plan_Lab_SheetModel
             {
                 Sampling_Plan_Lab_Sheet_Error = "",
                 Sampling_Plan_Lab_Sheet_Counter = 0,
                 Sampling_Plan_Lab_Sheet_ID = s.LabSheetID,
                 Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID = s.OtherServerLabSheetID,
                 Sampling_Plan_Lab_Sheet_Sampling_Plan_Name = s.SamplingPlanName,
                 Sampling_Plan_Lab_Sheet_Province = (province == null ? ServiceRes.Empty : province),
                 Sampling_Plan_Lab_Sheet_For_Group_Name = p.ForGroupName,
                 Sampling_Plan_Lab_Sheet_Year = s.Year,
                 Sampling_Plan_Lab_Sheet_Month = s.Month,
                 Sampling_Plan_Lab_Sheet_Day = s.Day,
                 Sampling_Plan_Lab_Sheet_Access_Code = p.AccessCode,
                 Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                 Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                 Sampling_Plan_Lab_Sheet_Subsector_Name_Short = (subsector.Contains(" ") ? subsector.Substring(0, subsector.IndexOf(" ")) : subsector),
                 Sampling_Plan_Lab_Sheet_Subsector_Name_Long = subsector,
                 Sampling_Plan_Lab_Sheet_Sampling_Plan_Type = (SamplingPlanTypeEnum?)s.SamplingPlanType,
                 Sampling_Plan_Lab_Sheet_Sample_Type = s.SampleType.ToString(),
                 Sampling_Plan_Lab_Sheet_Lab_Sheet_Type = (LabSheetTypeEnum?)s.LabSheetType,
                 Sampling_Plan_Lab_Sheet_Status = (LabSheetStatusEnum?)s.LabSheetStatus,
                 Sampling_Plan_Lab_Sheet_File_Name = s.FileName,
                 Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local = s.FileLastModifiedDate_Local,
                 Sampling_Plan_Lab_Sheet_File_Content = s.FileContent,
                 Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name = contactApproved.contactName,
                 Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial = contactApproved.contactInitial,
                 Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time = s.AcceptedOrRejectedDateTime,
                 Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                 Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name = contact.contactName,
                 Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet(reportSampling_Plan_Lab_SheetModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Counter = reportSampling_Plan_Lab_SheetModelQ.Count() } };

                reportSampling_Plan_Lab_SheetModelList = reportSampling_Plan_Lab_SheetModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSampling_Plan_Lab_SheetModel>() { new ReportSampling_Plan_Lab_SheetModel() { Sampling_Plan_Lab_Sheet_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSampling_Plan_Lab_SheetModel reportSampling_Plan_Lab_SheetModel in reportSampling_Plan_Lab_SheetModelList)
            {
                if (reportTreeNodeList.Where(c => c.Text == "Sampling_Plan_Lab_Sheet_Sample_Type").Any())
                {
                    List<string> NumbTextList = reportSampling_Plan_Lab_SheetModel.Sampling_Plan_Lab_Sheet_Sample_Type.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + ", ";
                    }
                    reportSampling_Plan_Lab_SheetModel.Sampling_Plan_Lab_Sheet_Sample_Type = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }

            }

            foreach (ReportSampling_Plan_Lab_SheetModel reportSampling_Plan_Lab_SheetModel in reportSampling_Plan_Lab_SheetModelList)
            {
                Counter += 1;
                reportSampling_Plan_Lab_SheetModel.Sampling_Plan_Lab_Sheet_Counter = Counter;
            }

            return reportSampling_Plan_Lab_SheetModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}