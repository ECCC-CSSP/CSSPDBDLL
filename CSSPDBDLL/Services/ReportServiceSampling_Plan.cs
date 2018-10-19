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
    public partial class ReportServiceSampling_Plan : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        public TVFileService _TVFileService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportServiceSampling_Plan(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVFileService = new TVFileService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSampling_PlanModel> GetReportSampling_PlanModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSampling_PlanModel> reportSampling_PlanModelList = new List<ReportSampling_PlanModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Sampling_Plan";
            int Counter = 0;
            IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Province)
                    return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.SamplingPlan.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Province)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSampling_PlanModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Province)
            {
                reportSampling_PlanModelQ =
                (from p in db.SamplingPlans
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == p.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactCreator = (from cc in db.Contacts
                                       let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                       let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                       where cc.ContactTVItemID == p.CreatorTVItemID
                                       select new { contactName, contactInitial }).FirstOrDefault()
                 let province = (from cl in db.TVItemLanguages where cl.TVItemID == p.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault()
                 where p.ProvinceTVItemID == UnderTVItemID
                 select new ReportSampling_PlanModel
                 {
                     Sampling_Plan_Error = "",
                     Sampling_Plan_Counter = 0,
                     Sampling_Plan_ID = p.SamplingPlanID,
                     Sampling_Plan_Sampling_Plan_Name = p.SamplingPlanName,
                     Sampling_Plan_For_Group_Name = p.ForGroupName,
                     Sampling_Plan_Sample_Type = p.SampleType.ToString(),
                     Sampling_Plan_Sampling_Plan_Type = (SamplingPlanTypeEnum?)p.SamplingPlanType,
                     Sampling_Plan_Lab_Sheet_Type = (LabSheetTypeEnum?)p.LabSheetType,
                     Sampling_Plan_Province = (province == null ? ServiceRes.Empty : province),
                     Sampling_Plan_Creator_Name = contactCreator.contactName,
                     Sampling_Plan_Creator_Initial = contactCreator.contactInitial,
                     Sampling_Plan_Year = p.Year,
                     Sampling_Plan_Access_Code = p.AccessCode,
                     Sampling_Plan_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                     Sampling_Plan_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                     Sampling_Plan_Sampling_Plan_File = p.SamplingPlanFileTVItemID.ToString(),
                     Sampling_Plan_Last_Update_Date_UTC = p.LastUpdateDate_UTC,
                     Sampling_Plan_Last_Update_Contact_Name = contact.contactName,
                     Sampling_Plan_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportSampling_PlanModelQ =
                     (from t in db.TVItems
                      from p in db.SamplingPlans
                      let contact = (from cc in db.Contacts
                                     let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                     let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                     where cc.ContactTVItemID == p.LastUpdateContactTVItemID
                                     select new { contactName, contactInitial }).FirstOrDefault()
                      let contactCreator = (from cc in db.Contacts
                                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                            where cc.ContactTVItemID == p.CreatorTVItemID
                                            select new { contactName, contactInitial }).FirstOrDefault()
                      let province = (from cl in db.TVItemLanguages where cl.TVItemID == p.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault()
                      where t.TVItemID == p.ProvinceTVItemID
                      && t.TVType == (int)TVTypeEnum.Province
                      && t.TVPath.StartsWith(tvItem.TVPath + "p")
                      select new ReportSampling_PlanModel
                      {
                          Sampling_Plan_Error = "",
                          Sampling_Plan_Counter = 0,
                          Sampling_Plan_ID = p.SamplingPlanID,
                          Sampling_Plan_Sampling_Plan_Name = p.SamplingPlanName,
                          Sampling_Plan_For_Group_Name = p.ForGroupName,
                          Sampling_Plan_Sample_Type = p.SampleType.ToString(),
                          Sampling_Plan_Sampling_Plan_Type = (SamplingPlanTypeEnum?)p.SamplingPlanType,
                          Sampling_Plan_Lab_Sheet_Type = (LabSheetTypeEnum?)p.LabSheetType,
                          Sampling_Plan_Province = (province == null ? ServiceRes.Empty : province),
                          Sampling_Plan_Creator_Name = contactCreator.contactName,
                          Sampling_Plan_Creator_Initial = contactCreator.contactInitial,
                          Sampling_Plan_Year = p.Year,
                          Sampling_Plan_Access_Code = p.AccessCode,
                          Sampling_Plan_Daily_Duplicate_Precision_Criteria = (float?)p.DailyDuplicatePrecisionCriteria,
                          Sampling_Plan_Intertech_Duplicate_Precision_Criteria = (float?)p.IntertechDuplicatePrecisionCriteria,
                          Sampling_Plan_Sampling_Plan_File = p.SamplingPlanFileTVItemID.ToString(),
                          Sampling_Plan_Last_Update_Date_UTC = p.LastUpdateDate_UTC,
                          Sampling_Plan_Last_Update_Contact_Name = contact.contactName,
                          Sampling_Plan_Last_Update_Contact_Initial = contact.contactInitial,
                      });
            }

            try
            {
                reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan(reportSampling_PlanModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Counter = reportSampling_PlanModelQ.Count() } };

                reportSampling_PlanModelList = reportSampling_PlanModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSampling_PlanModel reportSampling_PlanModel in reportSampling_PlanModelList)
            {

                if (reportTreeNodeList.Where(c => c.Text == "Sampling_Plan_Sampling_Plan_File").Any())
                {
                    int TVFileTVItemID = int.Parse(reportSampling_PlanModel.Sampling_Plan_Sampling_Plan_File);

                    if (TVFileTVItemID == 0)
                    {
                        reportSampling_PlanModel.Sampling_Plan_Sampling_Plan_File = ServiceRes.Empty;
                    }
                    else
                    {
                        TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithTVFileTVItemIDDB(TVFileTVItemID);
                        if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
                            return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.TVFileTVItemID, TVFileTVItemID.ToString()) } };

                        FileInfo fi = new FileInfo(_TVFileService.ChoseEDriveOrCDrive(tvFileModel.ServerFilePath) + tvFileModel.ServerFileName);
                        if (!fi.Exists)
                            return new List<ReportSampling_PlanModel>() { new ReportSampling_PlanModel() { Sampling_Plan_Error = string.Format(ServiceRes.File_DoesNotExist, fi.FullName) } };

                        StreamReader sr = fi.OpenText();
                        string FileContentText = sr.ReadToEnd();
                        sr.Close();

                        reportSampling_PlanModel.Sampling_Plan_Sampling_Plan_File = FileContentText;
                    }

                }

                if (reportTreeNodeList.Where(c => c.Text == "Sampling_Plan_Sample_Type").Any())
                {
                    List<string> NumbTextList = reportSampling_PlanModel.Sampling_Plan_Sample_Type.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + ", ";
                    }
                    reportSampling_PlanModel.Sampling_Plan_Sample_Type = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }

            }

            foreach (ReportSampling_PlanModel reportSampling_PlanModel in reportSampling_PlanModelList)
            {
                Counter += 1;
                reportSampling_PlanModel.Sampling_Plan_Counter = Counter;
            }

            return reportSampling_PlanModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}