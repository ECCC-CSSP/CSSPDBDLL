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
    public partial class ReportServiceHydrometric_Site_Rating_Curve_Value : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceHydrometric_Site_Rating_Curve_Value(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportHydrometric_Site_Rating_Curve_ValueModel> GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelList = new List<ReportHydrometric_Site_Rating_Curve_ValueModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Hydrometric_Site_Rating_Curve_Value";
            int Counter = 0;
            IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Hydrometric_Site_Rating_Curve")
                return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Hydrometric_Site_Rating_Curve", ParentTagItem) } };

            RatingCurve ratingCurve = (from c in db.RatingCurves
                                       where c.RatingCurveID == UnderTVItemID
                                       select c).FirstOrDefault();

            if (ratingCurve == null)
                return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurve, ServiceRes.RatingCurveID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportHydrometric_Site_Rating_Curve_ValueModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Error = retStr } };

            reportHydrometric_Site_Rating_Curve_ValueModelQ =
                (from rcv in db.RatingCurveValues
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == rcv.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where rcv.RatingCurveID == UnderTVItemID
                 select new ReportHydrometric_Site_Rating_Curve_ValueModel
                 {
                     Hydrometric_Site_Rating_Curve_Value_Error = "",
                     Hydrometric_Site_Rating_Curve_Value_Counter = 0,
                     Hydrometric_Site_Rating_Curve_Value_ID = rcv.RatingCurveValueID,
                     Hydrometric_Site_Rating_Curve_Value_Stage_Value_m = (float?)rcv.StageValue_m,
                     Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s = (float?)rcv.DischargeValue_m3_s,
                     Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC = rcv.LastUpdateDate_UTC,
                     Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name = contact.contactName,
                     Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial = contact.contactInitial,
                 });

            try
            {
                reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Error = retStr } };

                if (CountOnly)
                    return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Counter = reportHydrometric_Site_Rating_Curve_ValueModelQ.Count() } };

                reportHydrometric_Site_Rating_Curve_ValueModelList = reportHydrometric_Site_Rating_Curve_ValueModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportHydrometric_Site_Rating_Curve_ValueModel>() { new ReportHydrometric_Site_Rating_Curve_ValueModel() { Hydrometric_Site_Rating_Curve_Value_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportHydrometric_Site_Rating_Curve_ValueModel reportHydrometric_Site_Rating_Curve_ValueModel in reportHydrometric_Site_Rating_Curve_ValueModelList)
            {
                Counter += 1;
                reportHydrometric_Site_Rating_Curve_ValueModel.Hydrometric_Site_Rating_Curve_Value_Counter = Counter;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}