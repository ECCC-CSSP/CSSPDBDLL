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
    public partial class ReportServiceSampling_Plan_Subsector : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSampling_Plan_Subsector(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSampling_Plan_SubsectorModel> GetReportSampling_Plan_SubsectorModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelList = new List<ReportSampling_Plan_SubsectorModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Sampling_Plan_Subsector";
            int Counter = 0;
            IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            SamplingPlan SamplingPlan = (from c in db.SamplingPlans
                                 where c.SamplingPlanID == UnderTVItemID
                                 select c).FirstOrDefault();

            if (SamplingPlan == null)
                return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SamplingPlan, ServiceRes.SamplingPlanID, UnderTVItemID.ToString()) } };

            if (ParentTagItem != "Sampling_Plan")
                return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.SamplingPlan.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSampling_Plan_SubsectorModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Error = retStr } };

            reportSampling_Plan_SubsectorModelQ =
            (from p in db.SamplingPlans
             from s in db.SamplingPlanSubsectors
             let mp = (from m in db.MapInfos
                       from mp in db.MapInfoPoints
                       where m.MapInfoID == mp.MapInfoID
                       && m.TVItemID == s.SubsectorTVItemID
                       && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                       select mp).FirstOrDefault()
             let subsector = (from cl in db.TVItemLanguages
                              where cl.TVItemID == s.SubsectorTVItemID
                              && cl.Language == (int)Language
                              select cl.TVText).FirstOrDefault()
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where p.SamplingPlanID == s.SamplingPlanID
             && s.SamplingPlanID == UnderTVItemID
             select new ReportSampling_Plan_SubsectorModel
             {
                 Sampling_Plan_Subsector_Error = "",
                 Sampling_Plan_Subsector_Counter = 0,
                 Sampling_Plan_Subsector_ID = s.SamplingPlanSubsectorID,
                 Sampling_Plan_Subsector_Name_Short = (subsector.Contains(" ") ? subsector.Substring(0, subsector.IndexOf(" ")) : subsector),
                 Sampling_Plan_Subsector_Name_Long = subsector,
                 Sampling_Plan_Subsector_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                 Sampling_Plan_Subsector_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 Sampling_Plan_Subsector_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                 Sampling_Plan_Subsector_Last_Update_Contact_Name = contact.contactName,
                 Sampling_Plan_Subsector_Last_Update_Contact_Initial = contact.contactInitial,
             });


            try
            {
                reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector(reportSampling_Plan_SubsectorModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Counter = reportSampling_Plan_SubsectorModelQ.Count() } };

                reportSampling_Plan_SubsectorModelList = reportSampling_Plan_SubsectorModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSampling_Plan_SubsectorModel>() { new ReportSampling_Plan_SubsectorModel() { Sampling_Plan_Subsector_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSampling_Plan_SubsectorModel reportSampling_Plan_SubsectorModel in reportSampling_Plan_SubsectorModelList)
            {
                Counter += 1;
                reportSampling_Plan_SubsectorModel.Sampling_Plan_Subsector_Counter = Counter;
            }

            return reportSampling_Plan_SubsectorModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}