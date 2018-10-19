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
    public partial class ReportServiceSubsector_Hydrometric_Site_Rating_Curve : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Hydrometric_Site_Rating_Curve(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelList = new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Hydrometric_Site_Rating_Curve";
            int Counter = 0;
            IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Subsector_Hydrometric_Site")
                return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Hydrometric_Site", ParentTagItem) } };

            HydrometricSite HydrometricSite = (from c in db.HydrometricSites
                                               where c.HydrometricSiteTVItemID == UnderTVItemID
                                               select c).FirstOrDefault();

            if (HydrometricSite == null)
                return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Hydrometric_Site_Rating_CurveModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Error = retStr } };

            reportSubsector_Hydrometric_Site_Rating_CurveModelQ =
                (from c in db.HydrometricSites
                 from rc in db.RatingCurves
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == rc.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.HydrometricSiteID == rc.HydrometricSiteID
                 && c.HydrometricSiteTVItemID == UnderTVItemID
                 select new ReportSubsector_Hydrometric_Site_Rating_CurveModel
                 {
                     Subsector_Hydrometric_Site_Rating_Curve_Error = "",
                     Subsector_Hydrometric_Site_Rating_Curve_Counter = 0,
                     Subsector_Hydrometric_Site_Rating_Curve_ID = rc.RatingCurveID,
                     Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number = rc.RatingCurveNumber,
                     Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC = rc.LastUpdateDate_UTC,
                     Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial = contact.contactInitial,
                 });

            try
            {
                reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Counter = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Count() } };

                reportSubsector_Hydrometric_Site_Rating_CurveModelList = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_Hydrometric_Site_Rating_CurveModel>() { new ReportSubsector_Hydrometric_Site_Rating_CurveModel() { Subsector_Hydrometric_Site_Rating_Curve_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_Hydrometric_Site_Rating_CurveModel reportSubsector_Hydrometric_Site_Rating_CurveModel in reportSubsector_Hydrometric_Site_Rating_CurveModelList)
            {
                Counter += 1;
                reportSubsector_Hydrometric_Site_Rating_CurveModel.Subsector_Hydrometric_Site_Rating_Curve_Counter = Counter;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}