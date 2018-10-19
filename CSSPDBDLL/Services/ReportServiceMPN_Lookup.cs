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
    public partial class ReportServiceMPN_Lookup : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportServiceMPN_Lookup(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMPN_LookupModel> GetReportMPN_LookupModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMPN_LookupModel> reportMPN_LookupModelList = new List<ReportMPN_LookupModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MPN_Lookup";
            int Counter = 0;
            IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
            if (tvItemModelRoot == null)
                return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Error = ServiceRes.CouldNotFindRoot } };

            if (UnderTVItemID != tvItemModelRoot.TVItemID)
                return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Root.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMPN_LookupModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Error = retStr } };

            reportMPN_LookupModelQ =
            (from c in db.MWQMLookupMPNs
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == c.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             select new ReportMPN_LookupModel
             {
                 MPN_Lookup_Error = "",
                 MPN_Lookup_Counter = 0,
                 MPN_Lookup_ID = c.MWQMLookupMPNID,
                 MPN_Lookup_Tubes_10 = c.Tubes10,
                 MPN_Lookup_Tubes_1_0 = c.Tubes1,
                 MPN_Lookup_Tubes_0_1 = c.Tubes01,
                 MPN_Lookup_MPN_100_ml = c.MPN_100ml,
                 MPN_Lookup_Last_Update_Contact_Name = contact.contactName,
                 MPN_Lookup_Last_Update_Contact_Initial = contact.contactInitial,
                 MPN_Lookup_Last_Update_Date_And_Time_UTC = c.LastUpdateDate_UTC,
             });

            try
            {
                reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup(reportMPN_LookupModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Counter = reportMPN_LookupModelQ.Count() } };

                reportMPN_LookupModelList = reportMPN_LookupModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMPN_LookupModel>() { new ReportMPN_LookupModel() { MPN_Lookup_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMPN_LookupModel reportMPN_LookupModel in reportMPN_LookupModelList)
            {
                Counter += 1;
                reportMPN_LookupModel.MPN_Lookup_Counter = Counter;
            }

            return reportMPN_LookupModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}