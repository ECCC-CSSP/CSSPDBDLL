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
    public partial class ReportServicePol_Source_Site_Address : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServicePol_Source_Site_Address(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportPol_Source_Site_AddressModel> GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelList = new List<ReportPol_Source_Site_AddressModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Pol_Source_Site_Address";
            int Counter = 0;
            IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.PolSourceSite)
                    return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.PolSourceSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.PolSourceSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportPol_Source_Site_AddressModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.PolSourceSite)
            {
                reportPol_Source_Site_AddressModelQ =
                (from c in db.TVItems
                 from inf in db.PolSourceSites
                 from a in db.Addresses
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == a.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == inf.PolSourceSiteTVItemID
                 && inf.CivicAddressTVItemID == a.AddressTVItemID
                 && c.TVType == (int)TVTypeEnum.PolSourceSite
                 && c.TVItemID == UnderTVItemID
                 select new ReportPol_Source_Site_AddressModel
                 {
                     Pol_Source_Site_Address_Error = "",
                     Pol_Source_Site_Address_Counter = 0,
                     Pol_Source_Site_Address_ID = a.AddressTVItemID,
                     Pol_Source_Site_Address_Type = (AddressTypeEnum?)a.AddressType,
                     Pol_Source_Site_Address_Country = (from cl in db.TVItemLanguages where cl.TVItemID == a.CountryTVItemID select cl.TVText).FirstOrDefault(),
                     Pol_Source_Site_Address_Province = (from cl in db.TVItemLanguages where cl.TVItemID == a.ProvinceTVItemID select cl.TVText).FirstOrDefault(),
                     Pol_Source_Site_Address_Municipality = (from cl in db.TVItemLanguages where cl.TVItemID == a.MunicipalityTVItemID select cl.TVText).FirstOrDefault(),
                     Pol_Source_Site_Address_Street_Name = a.StreetName,
                     Pol_Source_Site_Address_Street_Number = a.StreetNumber,
                     Pol_Source_Site_Address_Street_Type = (StreetTypeEnum?)a.StreetType,
                     Pol_Source_Site_Address_Postal_Code = a.PostalCode,
                     Pol_Source_Site_Address_Google_Address_Text = a.GoogleAddressText,
                     Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC = a.LastUpdateDate_UTC,
                     Pol_Source_Site_Address_Last_Update_Contact_Name = contact.contactName,
                     Pol_Source_Site_Address_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportPol_Source_Site_AddressModelQ =
                (from c in db.TVItems
                 from inf in db.PolSourceSites
                 from a in db.Addresses
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == a.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == inf.PolSourceSiteTVItemID
                 && inf.CivicAddressTVItemID == a.AddressTVItemID
                 && c.TVType == (int)TVTypeEnum.PolSourceSite
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportPol_Source_Site_AddressModel
                 {
                     Pol_Source_Site_Address_Error = "",
                     Pol_Source_Site_Address_Counter = 0,
                     Pol_Source_Site_Address_ID = a.AddressTVItemID,
                     Pol_Source_Site_Address_Type = (AddressTypeEnum?)a.AddressType,
                     Pol_Source_Site_Address_Country = (from cl in db.TVItemLanguages where cl.TVItemID == a.CountryTVItemID select cl.TVText).FirstOrDefault(),
                     Pol_Source_Site_Address_Province = (from cl in db.TVItemLanguages where cl.TVItemID == a.ProvinceTVItemID select cl.TVText).FirstOrDefault(),
                     Pol_Source_Site_Address_Municipality = (from cl in db.TVItemLanguages where cl.TVItemID == a.MunicipalityTVItemID select cl.TVText).FirstOrDefault(),
                     Pol_Source_Site_Address_Street_Name = a.StreetName,
                     Pol_Source_Site_Address_Street_Number = a.StreetNumber,
                     Pol_Source_Site_Address_Street_Type = (StreetTypeEnum?)a.StreetType,
                     Pol_Source_Site_Address_Postal_Code = a.PostalCode,
                     Pol_Source_Site_Address_Google_Address_Text = a.GoogleAddressText,
                     Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC = a.LastUpdateDate_UTC,
                     Pol_Source_Site_Address_Last_Update_Contact_Name = contact.contactName,
                     Pol_Source_Site_Address_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address(reportPol_Source_Site_AddressModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = retStr } };

                if (CountOnly)
                    return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Counter = reportPol_Source_Site_AddressModelQ.Count() } };

                reportPol_Source_Site_AddressModelList = reportPol_Source_Site_AddressModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportPol_Source_Site_AddressModel>() { new ReportPol_Source_Site_AddressModel() { Pol_Source_Site_Address_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportPol_Source_Site_AddressModel reportPol_Source_Site_AddressModel in reportPol_Source_Site_AddressModelList)
            {
                Counter += 1;
                reportPol_Source_Site_AddressModel.Pol_Source_Site_Address_Counter = Counter;
            }

            return reportPol_Source_Site_AddressModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}