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
    public partial class ReportServiceMunicipality_Contact_Address : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMunicipality_Contact_Address(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMunicipality_Contact_AddressModel> GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            // the UnderTVItemID is the ContactTVItemID

            List<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelList = new List<ReportMunicipality_Contact_AddressModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Municipality_Contact_Address";
            int Counter = 0;
            IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "Municipality_Contact")
                return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Municipality_Contact", ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMunicipality_Contact_AddressModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Error = retStr } };

            reportMunicipality_Contact_AddressModelQ =
            (from c in db.TVItemLinks
             from a in db.Addresses
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == a.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where c.FromTVType == (int)TVTypeEnum.Contact
             && c.ToTVType == (int)TVTypeEnum.Address
             && c.FromTVItemID == UnderTVItemID
             && a.AddressTVItemID == c.ToTVItemID
             select new ReportMunicipality_Contact_AddressModel
             {
                 Municipality_Contact_Address_Error = "",
                 Municipality_Contact_Address_Counter = 0,
                 Municipality_Contact_Address_ID = a.AddressTVItemID,
                 Municipality_Contact_Address_Type = (AddressTypeEnum?)a.AddressType,
                 Municipality_Contact_Address_Country = a.CountryTVItemID.ToString(),
                 Municipality_Contact_Address_Province = a.ProvinceTVItemID.ToString(),
                 Municipality_Contact_Address_Municipality = a.MunicipalityTVItemID.ToString(),
                 Municipality_Contact_Address_Street_Name = a.StreetName,
                 Municipality_Contact_Address_Street_Number = a.StreetNumber,
                 Municipality_Contact_Address_Street_Type = (StreetTypeEnum?)a.StreetType,
                 Municipality_Contact_Address_Postal_Code = a.PostalCode,
                 Municipality_Contact_Address_Google_Address_Text = a.GoogleAddressText,
                 Municipality_Contact_Address_Last_Update_Date_And_Time_UTC = a.LastUpdateDate_UTC,
                 Municipality_Contact_Address_Last_Update_Contact_Name = contact.contactName,
                 Municipality_Contact_Address_Last_Update_Contact_Initial = contact.contactInitial,
             });


            try
            {
                reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address(reportMunicipality_Contact_AddressModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Counter = reportMunicipality_Contact_AddressModelQ.Count() } };

                reportMunicipality_Contact_AddressModelList = reportMunicipality_Contact_AddressModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMunicipality_Contact_AddressModel>() { new ReportMunicipality_Contact_AddressModel() { Municipality_Contact_Address_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMunicipality_Contact_AddressModel reportMunicipality_Contact_AddressModel in reportMunicipality_Contact_AddressModelList)
            {
                Counter += 1;
                reportMunicipality_Contact_AddressModel.Municipality_Contact_Address_Counter = Counter;
            }

            return reportMunicipality_Contact_AddressModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}