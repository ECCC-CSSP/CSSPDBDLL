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
    public partial class ReportServiceSubsector_Lab_Sheet : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Lab_Sheet(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Lab_SheetModel> GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelList = new List<ReportSubsector_Lab_SheetModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Lab_Sheet";
            int Counter = 0;
            IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                    return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Subsector.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Lab_SheetModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Subsector)
            {
                reportSubsector_Lab_SheetModelQ =
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
                 && c.TVItemID == s.SubsectorTVItemID
                 && s.SamplingPlanID == p.SamplingPlanID
                 && c.TVType == (int)TVTypeEnum.Subsector
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportSubsector_Lab_SheetModel
                 {
                     Subsector_Lab_Sheet_Error = "",
                     Subsector_Lab_Sheet_Counter = 0,
                     Subsector_Lab_Sheet_ID = s.LabSheetID,
                     Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID = s.OtherServerLabSheetID,
                     Subsector_Lab_Sheet_Sampling_Plan_Name = s.SamplingPlanName,
                     Subsector_Lab_Sheet_Province = (province == null ? ServiceRes.Empty : province),
                     Subsector_Lab_Sheet_For_Group_Name = p.ForGroupName,
                     Subsector_Lab_Sheet_Year = s.Year,
                     Subsector_Lab_Sheet_Month = s.Month,
                     Subsector_Lab_Sheet_Day = s.Day,
                     Subsector_Lab_Sheet_Access_Code = p.AccessCode,
                     Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                     Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                     Subsector_Lab_Sheet_Subsector_Name_Short = (subsector.Contains(" ") ? subsector.Substring(0, subsector.IndexOf(" ")) : subsector),
                     Subsector_Lab_Sheet_Subsector_Name_Long = subsector,
                     Subsector_Lab_Sheet_Sampling_Plan_Type = (SamplingPlanTypeEnum?)s.SamplingPlanType,
                     Subsector_Lab_Sheet_Sample_Type = s.SampleType.ToString(),
                     Subsector_Lab_Sheet_Type = (LabSheetTypeEnum?)s.LabSheetType,
                     Subsector_Lab_Sheet_Status = (LabSheetStatusEnum?)s.LabSheetStatus,
                     Subsector_Lab_Sheet_File_Name = s.FileName,
                     Subsector_Lab_Sheet_File_Last_Modified_Date_Local = s.FileLastModifiedDate_Local,
                     Subsector_Lab_Sheet_File_Content = s.FileContent,
                     Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name = contactApproval.contactName,
                     Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial = contactApproval.contactInitial,
                     Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time = s.AcceptedOrRejectedDateTime,
                     Subsector_Lab_Sheet_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                     Subsector_Lab_Sheet_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Lab_Sheet_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportSubsector_Lab_SheetModelQ =
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
                 && c.TVItemID == s.SubsectorTVItemID
                 && s.SamplingPlanID == p.SamplingPlanID
                 && c.TVType == (int)TVTypeEnum.Subsector
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportSubsector_Lab_SheetModel
                 {
                     Subsector_Lab_Sheet_Error = "",
                     Subsector_Lab_Sheet_Counter = 0,
                     Subsector_Lab_Sheet_ID = s.LabSheetID,
                     Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID = s.OtherServerLabSheetID,
                     Subsector_Lab_Sheet_Sampling_Plan_Name = s.SamplingPlanName,
                     Subsector_Lab_Sheet_Province = (province == null ? ServiceRes.Empty : province),
                     Subsector_Lab_Sheet_For_Group_Name = p.ForGroupName,
                     Subsector_Lab_Sheet_Year = s.Year,
                     Subsector_Lab_Sheet_Month = s.Month,
                     Subsector_Lab_Sheet_Day = s.Day,
                     Subsector_Lab_Sheet_Access_Code = p.AccessCode,
                     Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                     Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                     Subsector_Lab_Sheet_Subsector_Name_Short = (subsector.Contains(" ") ? subsector.Substring(0, subsector.IndexOf(" ")) : subsector),
                     Subsector_Lab_Sheet_Subsector_Name_Long = subsector,
                     Subsector_Lab_Sheet_Sampling_Plan_Type = (SamplingPlanTypeEnum?)s.SamplingPlanType,
                     Subsector_Lab_Sheet_Sample_Type = s.SampleType.ToString(),
                     Subsector_Lab_Sheet_Type = (LabSheetTypeEnum?)s.LabSheetType,
                     Subsector_Lab_Sheet_Status = (LabSheetStatusEnum?)s.LabSheetStatus,
                     Subsector_Lab_Sheet_File_Name = s.FileName,
                     Subsector_Lab_Sheet_File_Last_Modified_Date_Local = s.FileLastModifiedDate_Local,
                     Subsector_Lab_Sheet_File_Content = s.FileContent,
                     Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name = contactApproval.contactName,
                     Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial = contactApproval.contactInitial,
                     Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time = s.AcceptedOrRejectedDateTime,
                     Subsector_Lab_Sheet_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                     Subsector_Lab_Sheet_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Lab_Sheet_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet(reportSubsector_Lab_SheetModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Counter = reportSubsector_Lab_SheetModelQ.Count() } };

                reportSubsector_Lab_SheetModelList = reportSubsector_Lab_SheetModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_Lab_SheetModel>() { new ReportSubsector_Lab_SheetModel() { Subsector_Lab_Sheet_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_Lab_SheetModel reportSubsector_Lab_SheetModel in reportSubsector_Lab_SheetModelList)
            {
                if (reportTreeNodeList.Where(c => c.Text == "Subsector_Lab_Sheet_Sample_Type").Any())
                {
                    List<string> NumbTextList = reportSubsector_Lab_SheetModel.Subsector_Lab_Sheet_Sample_Type.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + " ";
                    }
                    reportSubsector_Lab_SheetModel.Subsector_Lab_Sheet_Sample_Type = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }
            }

            foreach (ReportSubsector_Lab_SheetModel reportSubsector_Lab_SheetModel in reportSubsector_Lab_SheetModelList)
            {
                Counter += 1;
                reportSubsector_Lab_SheetModel.Subsector_Lab_Sheet_Counter = Counter;
            }

            return reportSubsector_Lab_SheetModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}