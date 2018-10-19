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
    public partial class ReportServiceMWQM_Run_Lab_Sheet : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Run_Lab_Sheet(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_Run_Lab_SheetModel> GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelList = new List<ReportMWQM_Run_Lab_SheetModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Run_Lab_Sheet";
            int Counter = 0;
            IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMRun)
                    return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMRun.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMRun)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_Run_Lab_SheetModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MWQMRun)
            {
                reportMWQM_Run_Lab_SheetModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.LabSheets
                 from p in db.SamplingPlans
                 let province = (from cl in db.TVItemLanguages where cl.TVItemID == p.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault()
                 let subsector = (from cl in db.TVItemLanguages
                                  where cl.TVItemID == s.SubsectorTVItemID
                                  && cl.Language == (int)Language
                                  select cl.TVText).FirstOrDefault()
                 let mwqmRunName = (from cl in db.TVItemLanguages
                                    where cl.TVItemID == s.MWQMRunTVItemID
                                    && cl.Language == (int)Language
                                    select cl.TVText).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactApproval = (from cc in db.Contacts
                                        let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                        let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                        where cc.ContactTVItemID == s.AcceptedOrRejectedByContactTVItemID
                                        select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMRunTVItemID
                 && s.SamplingPlanID == p.SamplingPlanID
                 && c.TVType == (int)TVTypeEnum.MWQMRun
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportMWQM_Run_Lab_SheetModel
                 {
                     MWQM_Run_Lab_Sheet_Error = "",
                     MWQM_Run_Lab_Sheet_Counter = 0,
                     MWQM_Run_Lab_Sheet_ID = s.LabSheetID,
                     MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID = s.OtherServerLabSheetID,
                     MWQM_Run_Lab_Sheet_Sampling_Plan_Name = s.SamplingPlanName,
                     MWQM_Run_Lab_Sheet_Province = (province == null ? ServiceRes.Empty : province),
                     MWQM_Run_Lab_Sheet_For_Group_Name = p.ForGroupName,
                     MWQM_Run_Lab_Sheet_Year = s.Year,
                     MWQM_Run_Lab_Sheet_Month = s.Month,
                     MWQM_Run_Lab_Sheet_Day = s.Day,
                     MWQM_Run_Lab_Sheet_Access_Code = p.AccessCode,
                     MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                     MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                     MWQM_Run_Lab_Sheet_Subsector_Name_Short = (subsector.Contains(" ") ? subsector.Substring(0, subsector.IndexOf(" ")) : subsector),
                     MWQM_Run_Lab_Sheet_Subsector_Name_Long = subsector,
                     MWQM_Run_Lab_Sheet_MWQM_Run_Name = (mwqmRunName == null ? ServiceRes.Empty : mwqmRunName),
                     MWQM_Run_Lab_Sheet_Sampling_Plan_Type = (SamplingPlanTypeEnum?)s.SamplingPlanType,
                     MWQM_Run_Lab_Sheet_Sample_Type = s.SampleType.ToString(),
                     MWQM_Run_Lab_Sheet_Type = (LabSheetTypeEnum?)s.LabSheetType,
                     MWQM_Run_Lab_Sheet_Status = (LabSheetStatusEnum?)s.LabSheetStatus,
                     MWQM_Run_Lab_Sheet_File_Name = s.FileName,
                     MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local = s.FileLastModifiedDate_Local,
                     MWQM_Run_Lab_Sheet_File_Content = s.FileContent,
                     MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name = contactApproval.contactName,
                     MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial = contactApproval.contactInitial,
                     MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time = s.AcceptedOrRejectedDateTime,
                     MWQM_Run_Lab_Sheet_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                     MWQM_Run_Lab_Sheet_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportMWQM_Run_Lab_SheetModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.LabSheets
                 from p in db.SamplingPlans
                 let province = (from cl in db.TVItemLanguages where cl.TVItemID == p.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault()
                 let subsector = (from cl in db.TVItemLanguages
                                  where cl.TVItemID == s.SubsectorTVItemID
                                  && cl.Language == (int)Language
                                  select cl.TVText).FirstOrDefault()
                 let mwqmRunName = (from cl in db.TVItemLanguages
                                    where cl.TVItemID == s.MWQMRunTVItemID
                                    && cl.Language == (int)Language
                                    select cl.TVText).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactApproval = (from cc in db.Contacts
                                        let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                        let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                        where cc.ContactTVItemID == s.AcceptedOrRejectedByContactTVItemID
                                        select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMRunTVItemID
                 && s.SamplingPlanID == p.SamplingPlanID
                 && c.TVType == (int)TVTypeEnum.MWQMRun
                 && cl.Language == (int)Language
                   && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportMWQM_Run_Lab_SheetModel
                 {
                     MWQM_Run_Lab_Sheet_Error = "",
                     MWQM_Run_Lab_Sheet_Counter = 0,
                     MWQM_Run_Lab_Sheet_ID = s.LabSheetID,
                     MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID = s.OtherServerLabSheetID,
                     MWQM_Run_Lab_Sheet_Sampling_Plan_Name = s.SamplingPlanName,
                     MWQM_Run_Lab_Sheet_Province = (province == null ? ServiceRes.Empty : province),
                     MWQM_Run_Lab_Sheet_For_Group_Name = p.ForGroupName,
                     MWQM_Run_Lab_Sheet_Year = s.Year,
                     MWQM_Run_Lab_Sheet_Month = s.Month,
                     MWQM_Run_Lab_Sheet_Day = s.Day,
                     MWQM_Run_Lab_Sheet_Access_Code = p.AccessCode,
                     MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                     MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                     MWQM_Run_Lab_Sheet_Subsector_Name_Short = (subsector.Contains(" ") ? subsector.Substring(0, subsector.IndexOf(" ")) : subsector),
                     MWQM_Run_Lab_Sheet_Subsector_Name_Long = subsector,
                     MWQM_Run_Lab_Sheet_MWQM_Run_Name = (mwqmRunName == null ? ServiceRes.Empty : mwqmRunName),
                     MWQM_Run_Lab_Sheet_Sampling_Plan_Type = (SamplingPlanTypeEnum?)s.SamplingPlanType,
                     MWQM_Run_Lab_Sheet_Sample_Type = s.SampleType.ToString(),
                     MWQM_Run_Lab_Sheet_Type = (LabSheetTypeEnum?)s.LabSheetType,
                     MWQM_Run_Lab_Sheet_Status = (LabSheetStatusEnum?)s.LabSheetStatus,
                     MWQM_Run_Lab_Sheet_File_Name = s.FileName,
                     MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local = s.FileLastModifiedDate_Local,
                     MWQM_Run_Lab_Sheet_File_Content = s.FileContent,
                     MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name = contactApproval.contactName,
                     MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial = contactApproval.contactInitial,
                     MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time = s.AcceptedOrRejectedDateTime,
                     MWQM_Run_Lab_Sheet_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                     MWQM_Run_Lab_Sheet_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet(reportMWQM_Run_Lab_SheetModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Counter = reportMWQM_Run_Lab_SheetModelQ.Count() } };

                reportMWQM_Run_Lab_SheetModelList = reportMWQM_Run_Lab_SheetModelQ.Take(2).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_Run_Lab_SheetModel>() { new ReportMWQM_Run_Lab_SheetModel() { MWQM_Run_Lab_Sheet_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_Run_Lab_SheetModel reportMWQM_Run_Lab_SheetModel in reportMWQM_Run_Lab_SheetModelList)
            {
                if (reportTreeNodeList.Where(c => c.Text == "MWQM_Run_Lab_Sheet_Sample_Type").Any())
                {
                    List<string> NumbTextList = reportMWQM_Run_Lab_SheetModel.MWQM_Run_Lab_Sheet_Sample_Type.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + " ";
                    }
                    reportMWQM_Run_Lab_SheetModel.MWQM_Run_Lab_Sheet_Sample_Type = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }
            }

            foreach (ReportMWQM_Run_Lab_SheetModel reportMWQM_Run_Lab_SheetModel in reportMWQM_Run_Lab_SheetModelList)
            {
                Counter += 1;
                reportMWQM_Run_Lab_SheetModel.MWQM_Run_Lab_Sheet_Counter = Counter;
            }

            return reportMWQM_Run_Lab_SheetModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}