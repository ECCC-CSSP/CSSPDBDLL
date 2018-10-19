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
    public partial class ReportServiceSampling_Plan_Lab_Sheet_Tube_And_MPN_Detail : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSampling_Plan_Lab_Sheet_Tube_And_MPN_Detail(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> GetReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail";
            int Counter = 0;
            IQueryable<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in db.LabSheetTubeMPNDetails
                                                           where c.LabSheetDetailID == UnderTVItemID
                                                           select c).FirstOrDefault();

            if (labSheetTubeMPNDetail == null)
                return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail, ServiceRes.LabSheetDetailID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "Sampling_Plan_Lab_Sheet_Detail")
                return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Sampling_Plan_Lab_Sheet_Detail", ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = retStr } };

            reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelQ =
            (from lst in db.LabSheetTubeMPNDetails
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == lst.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where lst.LabSheetDetailID == UnderTVItemID
             select new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel
             {
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = "",
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Counter = 0,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID = lst.LabSheetTubeMPNDetailID,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Ordinal = lst.Ordinal,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site = lst.MWQMSiteTVItemID.ToString(),
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time = lst.SampleDateTime,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_MPN = lst.MPN,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 = lst.Tube10,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 = lst.Tube1_0,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 = lst.Tube0_1,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Salinity = (float?)lst.Salinity,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Temperature = (float?)lst.Temperature,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Processed_By = lst.ProcessedBy,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type = lst.SampleType.ToString(),
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment = lst.SiteComment,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC = lst.LastUpdateDate_UTC,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name = contact.contactName,
                 Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Tube_And_MPN_Detail(reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Counter = reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelQ.Count() } };

                reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel>() { new ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel() { Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel in reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList)
            {
                if (reportTreeNodeList.Where(c => c.Text == "Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type").Any())
                {
                    List<string> NumbTextList = reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel.Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + ", ";
                    }
                    reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel.Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }

            }

            foreach (ReportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel in reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList)
            {
                Counter += 1;
                reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModel.Sampling_Plan_Lab_Sheet_Tube_And_MPN_Detail_Counter = Counter;
            }

            return reportSampling_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}