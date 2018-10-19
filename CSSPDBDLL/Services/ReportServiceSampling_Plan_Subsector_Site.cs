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
    public partial class ReportServiceSampling_Plan_Subsector_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSampling_Plan_Subsector_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSampling_Plan_Subsector_SiteModel> GetReportSampling_Plan_Subsector_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelList = new List<ReportSampling_Plan_Subsector_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Sampling_Plan_Subsector_Site";
            int Counter = 0;
            IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            SamplingPlanSubsector SamplingPlanSubsector = (from c in db.SamplingPlanSubsectors
                                                   where c.SamplingPlanSubsectorID == UnderTVItemID
                                                   select c).FirstOrDefault();

            if (SamplingPlanSubsector == null)
                return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SamplingPlanSubsector, ServiceRes.SamplingPlanSubsectorID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "Sampling_Plan_Subsector")
                return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Sampling_Plan_Subsector", ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSampling_Plan_Subsector_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Error = retStr } };

            reportSampling_Plan_Subsector_SiteModelQ =
            (from s in db.SamplingPlanSubsectorSites
             let mp = (from m in db.MapInfos
                       from mp in db.MapInfoPoints
                       where m.MapInfoID == mp.MapInfoID
                       && m.TVItemID == s.MWQMSiteTVItemID
                       && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                       select mp).FirstOrDefault()
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where s.SamplingPlanSubsectorID == UnderTVItemID
             select new ReportSampling_Plan_Subsector_SiteModel
             {
                 Sampling_Plan_Subsector_Site_Error = "",
                 Sampling_Plan_Subsector_Site_Counter = 0,
                 Sampling_Plan_Subsector_Site_ID = s.MWQMSiteTVItemID,
                 Sampling_Plan_Subsector_Site_MWQM_Site = (from cl in db.TVItemLanguages
                                                       where cl.TVItemID == s.MWQMSiteTVItemID
                                                       && cl.Language == (int)Language
                                                       select cl.TVText).FirstOrDefault(),
                 Sampling_Plan_Subsector_Site_Is_Duplicate = s.IsDuplicate,
                 Sampling_Plan_Subsector_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                 Sampling_Plan_Subsector_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 Sampling_Plan_Subsector_Site_Last_Update_Date_UTC = s.LastUpdateDate_UTC,
                 Sampling_Plan_Subsector_Site_Last_Update_Contact_Name = contact.contactName,
                 Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Counter = reportSampling_Plan_Subsector_SiteModelQ.Count() } };

                reportSampling_Plan_Subsector_SiteModelList = reportSampling_Plan_Subsector_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSampling_Plan_Subsector_SiteModel>() { new ReportSampling_Plan_Subsector_SiteModel() { Sampling_Plan_Subsector_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSampling_Plan_Subsector_SiteModel reportSampling_Plan_Subsector_SiteModel in reportSampling_Plan_Subsector_SiteModelList)
            {
                Counter += 1;
                reportSampling_Plan_Subsector_SiteModel.Sampling_Plan_Subsector_Site_Counter = Counter;
            }

            return reportSampling_Plan_Subsector_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}