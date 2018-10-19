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
    public partial class ReportServiceMunicipality_Contact_Tel : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMunicipality_Contact_Tel(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMunicipality_Contact_TelModel> GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            // the UnderTVItemID is the ContactTVItemID

            List<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelList = new List<ReportMunicipality_Contact_TelModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Municipality_Contact_Tel";
            int Counter = 0;
            IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "Municipality_Contact")
                return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Municipality_Contact", ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMunicipality_Contact_TelModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Error = retStr } };

            reportMunicipality_Contact_TelModelQ =
            (from c in db.TVItemLinks
             from t in db.Tels
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == t.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where c.FromTVType == (int)TVTypeEnum.Contact
             && c.ToTVType == (int)TVTypeEnum.Tel
             && c.FromTVItemID == UnderTVItemID
             && t.TelTVItemID == c.ToTVItemID
             select new ReportMunicipality_Contact_TelModel
             {
                 Municipality_Contact_Tel_Error = "",
                 Municipality_Contact_Tel_Counter = 0,
                 Municipality_Contact_Tel_ID = t.TelTVItemID,
                 Municipality_Contact_Tel_Type = (TelTypeEnum?)t.TelType,
                 Municipality_Contact_Tel_Number = t.TelNumber,
                 Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC = t.LastUpdateDate_UTC,
                 Municipality_Contact_Tel_Last_Update_Contact_Name = contact.contactName,
                 Municipality_Contact_Tel_Last_Update_Contact_Initial = contact.contactInitial,
             });


            try
            {
                reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel(reportMunicipality_Contact_TelModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Counter = reportMunicipality_Contact_TelModelQ.Count() } };

                reportMunicipality_Contact_TelModelList = reportMunicipality_Contact_TelModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMunicipality_Contact_TelModel>() { new ReportMunicipality_Contact_TelModel() { Municipality_Contact_Tel_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMunicipality_Contact_TelModel reportMunicipality_Contact_TelModel in reportMunicipality_Contact_TelModelList)
            {
                Counter += 1;
                reportMunicipality_Contact_TelModel.Municipality_Contact_Tel_Counter = Counter;
            }

            return reportMunicipality_Contact_TelModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}