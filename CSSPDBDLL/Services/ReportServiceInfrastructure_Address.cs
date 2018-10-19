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
    public partial class ReportServiceInfrastructure_Address : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceInfrastructure_Address(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportInfrastructure_AddressModel> GetReportInfrastructure_AddressModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelList = new List<ReportInfrastructure_AddressModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Infrastructure_Address";
            int Counter = 0;
            IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                    return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Infrastructure.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportInfrastructure_AddressModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Infrastructure)
            {
                reportInfrastructure_AddressModelQ =
                (from c in db.TVItems
                 from inf in db.Infrastructures
                 from a in db.Addresses
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == a.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == inf.InfrastructureTVItemID
                 && inf.CivicAddressTVItemID == a.AddressTVItemID
                 && c.TVType == (int)TVTypeEnum.Infrastructure
                 && c.TVItemID == UnderTVItemID
                 select new ReportInfrastructure_AddressModel
                 {
                     Infrastructure_Address_Error = "",
                     Infrastructure_Address_Counter = 0,
                     Infrastructure_Address_ID = a.AddressTVItemID,
                     Infrastructure_Address_Type = (AddressTypeEnum?)a.AddressType,
                     Infrastructure_Address_Country = (from cl in db.TVItemLanguages where cl.TVItemID == a.CountryTVItemID select cl.TVText).FirstOrDefault(),
                     Infrastructure_Address_Province = (from cl in db.TVItemLanguages where cl.TVItemID == a.ProvinceTVItemID select cl.TVText).FirstOrDefault(),
                     Infrastructure_Address_Municipality = (from cl in db.TVItemLanguages where cl.TVItemID == a.MunicipalityTVItemID select cl.TVText).FirstOrDefault(),
                     Infrastructure_Address_Street_Name = a.StreetName,
                     Infrastructure_Address_Street_Number = a.StreetNumber,
                     Infrastructure_Address_Street_Type = (StreetTypeEnum?)a.StreetType,
                     Infrastructure_Address_Postal_Code = a.PostalCode,
                     Infrastructure_Address_Google_Address_Text = a.GoogleAddressText,
                     Infrastructure_Address_Last_Update_Date_And_Time_UTC = a.LastUpdateDate_UTC,
                     Infrastructure_Address_Last_Update_Contact_Name = contact.contactName,
                     Infrastructure_Address_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportInfrastructure_AddressModelQ =
                (from c in db.TVItems
                 from inf in db.Infrastructures
                 from a in db.Addresses
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == a.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == inf.InfrastructureTVItemID
                 && inf.CivicAddressTVItemID == a.AddressTVItemID
                 && c.TVType == (int)TVTypeEnum.Infrastructure
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportInfrastructure_AddressModel
                 {
                     Infrastructure_Address_Error = "",
                     Infrastructure_Address_Counter = 0,
                     Infrastructure_Address_ID = a.AddressTVItemID,
                     Infrastructure_Address_Type = (AddressTypeEnum?)a.AddressType,
                     Infrastructure_Address_Country = (from cl in db.TVItemLanguages where cl.TVItemID == a.CountryTVItemID select cl.TVText).FirstOrDefault(),
                     Infrastructure_Address_Province = (from cl in db.TVItemLanguages where cl.TVItemID == a.ProvinceTVItemID select cl.TVText).FirstOrDefault(),
                     Infrastructure_Address_Municipality = (from cl in db.TVItemLanguages where cl.TVItemID == a.MunicipalityTVItemID select cl.TVText).FirstOrDefault(),
                     Infrastructure_Address_Street_Name = a.StreetName,
                     Infrastructure_Address_Street_Number = a.StreetNumber,
                     Infrastructure_Address_Street_Type = (StreetTypeEnum?)a.StreetType,
                     Infrastructure_Address_Postal_Code = a.PostalCode,
                     Infrastructure_Address_Google_Address_Text = a.GoogleAddressText,
                     Infrastructure_Address_Last_Update_Date_And_Time_UTC = a.LastUpdateDate_UTC,
                     Infrastructure_Address_Last_Update_Contact_Name = contact.contactName,
                     Infrastructure_Address_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address(reportInfrastructure_AddressModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = retStr } };

                if (CountOnly)
                    return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Counter = reportInfrastructure_AddressModelQ.Count() } };

                reportInfrastructure_AddressModelList = reportInfrastructure_AddressModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportInfrastructure_AddressModel>() { new ReportInfrastructure_AddressModel() { Infrastructure_Address_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportInfrastructure_AddressModel reportInfrastructure_AddressModel in reportInfrastructure_AddressModelList)
            {
                Counter += 1;
                reportInfrastructure_AddressModel.Infrastructure_Address_Counter = Counter;
            }

            return reportInfrastructure_AddressModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}