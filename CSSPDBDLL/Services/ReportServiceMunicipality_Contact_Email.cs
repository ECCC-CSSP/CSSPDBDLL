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
    public partial class ReportServiceMunicipality_Contact_Email : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMunicipality_Contact_Email(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMunicipality_Contact_EmailModel> GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            // the UnderTVItemID is the ContactTVItemID

            List<ReportMunicipality_Contact_EmailModel> reportMunicipality_Contact_EmailModelList = new List<ReportMunicipality_Contact_EmailModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Municipality_Contact_Email";
            int Counter = 0;
            IQueryable<ReportMunicipality_Contact_EmailModel> reportMunicipality_Contact_EmailModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "Municipality_Contact")
                return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Municipality_Contact", ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMunicipality_Contact_EmailModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Error = retStr } };

            reportMunicipality_Contact_EmailModelQ =
            (from c in db.TVItemLinks
             from e in db.Emails
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == e.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where c.FromTVType == (int)TVTypeEnum.Contact
             && c.ToTVType == (int)TVTypeEnum.Email
             && c.FromTVItemID == UnderTVItemID
             && e.EmailTVItemID == c.ToTVItemID
             select new ReportMunicipality_Contact_EmailModel
             {
                 Municipality_Contact_Email_Error = "",
                 Municipality_Contact_Email_Counter = 0,
                 Municipality_Contact_Email_ID = e.EmailTVItemID,
                 Municipality_Contact_Email_Type = (EmailTypeEnum?)e.EmailType,
                 Municipality_Contact_Email_Address = e.EmailAddress,
                 Municipality_Contact_Email_Last_Update_Date_And_Time_UTC = e.LastUpdateDate_UTC,
                 Municipality_Contact_Email_Last_Update_Contact_Name = contact.contactName,
                 Municipality_Contact_Email_Last_Update_Contact_Initial = contact.contactInitial,
             });


            try
            {
                reportMunicipality_Contact_EmailModelQ = ReportServiceGeneratedMunicipality_Contact_Email(reportMunicipality_Contact_EmailModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Counter = reportMunicipality_Contact_EmailModelQ.Count() } };

                reportMunicipality_Contact_EmailModelList = reportMunicipality_Contact_EmailModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMunicipality_Contact_EmailModel>() { new ReportMunicipality_Contact_EmailModel() { Municipality_Contact_Email_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMunicipality_Contact_EmailModel reportMunicipality_Contact_EmailModel in reportMunicipality_Contact_EmailModelList)
            {
                Counter += 1;
                reportMunicipality_Contact_EmailModel.Municipality_Contact_Email_Counter = Counter;
            }

            return reportMunicipality_Contact_EmailModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}