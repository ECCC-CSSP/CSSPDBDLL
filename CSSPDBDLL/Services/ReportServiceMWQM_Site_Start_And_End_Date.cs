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
    public partial class ReportServiceMWQM_Site_Start_And_End_Date : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Site_Start_And_End_Date(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_Site_Start_And_End_DateModel> GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelList = new List<ReportMWQM_Site_Start_And_End_DateModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Site_Start_And_End_Date";
            int Counter = 0;
            IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMSite)
                    return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_Site_Start_And_End_DateModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MWQMSite)
            {
                reportMWQM_Site_Start_And_End_DateModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.MWQMSiteStartEndDates
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMSiteTVItemID
                 && c.TVType == (int)TVTypeEnum.MWQMSite
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportMWQM_Site_Start_And_End_DateModel
                 {
                     MWQM_Site_Start_And_End_Date_Error = "",
                     MWQM_Site_Start_And_End_Date_Counter = 0,
                     MWQM_Site_Start_And_End_Date_ID = s.MWQMSiteStartEndDateID,
                     MWQM_Site_Start_And_End_Date_Start_Date = s.StartDate,
                     MWQM_Site_Start_And_End_Date_End_Date = s.EndDate,
                     MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC = s.LastUpdateDate_UTC,
                     MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportMWQM_Site_Start_And_End_DateModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.MWQMSiteStartEndDates
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMSiteTVItemID
                 && c.TVType == (int)TVTypeEnum.MWQMSite
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportMWQM_Site_Start_And_End_DateModel
                 {
                     MWQM_Site_Start_And_End_Date_Error = "",
                     MWQM_Site_Start_And_End_Date_Counter = 0,
                     MWQM_Site_Start_And_End_Date_ID = s.MWQMSiteStartEndDateID,
                     MWQM_Site_Start_And_End_Date_Start_Date = s.StartDate,
                     MWQM_Site_Start_And_End_Date_End_Date = s.EndDate,
                     MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC = s.LastUpdateDate_UTC,
                     MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Counter = reportMWQM_Site_Start_And_End_DateModelQ.Count() } };

                reportMWQM_Site_Start_And_End_DateModelList = reportMWQM_Site_Start_And_End_DateModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_Site_Start_And_End_DateModel>() { new ReportMWQM_Site_Start_And_End_DateModel() { MWQM_Site_Start_And_End_Date_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_Site_Start_And_End_DateModel reportMWQM_Site_Start_And_End_DateModel in reportMWQM_Site_Start_And_End_DateModelList)
            {
                Counter += 1;
                reportMWQM_Site_Start_And_End_DateModel.MWQM_Site_Start_And_End_Date_Counter = Counter;
            }

            return reportMWQM_Site_Start_And_End_DateModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}