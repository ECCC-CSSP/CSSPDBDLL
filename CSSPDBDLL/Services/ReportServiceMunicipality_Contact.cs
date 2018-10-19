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
    public partial class ReportServiceMunicipality_Contact : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMunicipality_Contact(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMunicipality_ContactModel> GetReportMunicipality_ContactModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMunicipality_ContactModel> reportMunicipality_ContactModelList = new List<ReportMunicipality_ContactModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Municipality_Contact";
            int Counter = 0;
            IQueryable<ReportMunicipality_ContactModel> reportMunicipality_ContactModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Municipality)
                    return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Infrastructure.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Municipality)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMunicipality_ContactModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Municipality)
            {
                reportMunicipality_ContactModelQ =
                (from c in db.TVItems
                 from t in db.TVItemLinks
                 from cont in db.Contacts
                 let email = (from c in db.TVItemLinks
                              from t in db.Emails
                              where c.ToTVItemID == t.EmailTVItemID
                              && c.FromTVItemID == cont.ContactTVItemID
                              && c.FromTVType == (int)TVTypeEnum.Contact
                              && c.ToTVType == (int)TVTypeEnum.Email
                              select t).FirstOrDefault()
                 let tel = (from c in db.TVItemLinks
                            from t in db.Tels
                            where c.ToTVItemID == t.TelTVItemID
                            && c.FromTVItemID == cont.ContactTVItemID
                            && c.FromTVType == (int)TVTypeEnum.Contact
                            && c.ToTVType == (int)TVTypeEnum.Tel
                            select t).FirstOrDefault()
                 let addr = (from c in db.Addresses
                             let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let mip = (from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where mi.MapInfoID == mip.MapInfoID
                                        && mi.TVItemID == c.AddressTVItemID
                                        && mi.TVType == (int)TVTypeEnum.Address
                                        && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                        select mip).FirstOrDefault()
                             where c.AddressTVItemID == t.ToTVItemID
                             select new AddressModel
                             {
                                 Error = "",
                                 AddressID = c.AddressID,
                                 AddressTVItemID = c.AddressTVItemID,
                                 AddressTVText = "",
                                 AddressType = (AddressTypeEnum)c.AddressType,
                                 AddressTypeText = "",
                                 MunicipalityTVItemID = c.MunicipalityTVItemID,
                                 MunicipalityTVText = muni,
                                 ProvinceTVItemID = c.ProvinceTVItemID,
                                 ProvinceTVText = prov,
                                 CountryTVItemID = c.CountryTVItemID,
                                 CountryTVText = country,
                                 StreetName = c.StreetName,
                                 StreetNumber = c.StreetNumber,
                                 StreetType = (StreetTypeEnum)c.StreetType,
                                 StreetTypeText = "",
                                 PostalCode = c.PostalCode,
                                 GoogleAddressText = c.GoogleAddressText,
                                 LatLngText = mip.Lat + " " + mip.Lng,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                             }).FirstOrDefault<AddressModel>()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == t.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == t.FromTVItemID
                 && t.FromTVType == (int)TVTypeEnum.Municipality
                 && t.ToTVType == (int)TVTypeEnum.Contact
                 && c.TVType == (int)TVTypeEnum.Municipality
                 && cont.ContactTVItemID == t.ToTVItemID
                 && c.TVItemID == UnderTVItemID
                 select new ReportMunicipality_ContactModel
                 {
                     Municipality_Contact_Error = "",
                     Municipality_Contact_Counter = 0,
                     Municipality_Contact_ID = t.ToTVItemID,
                     Municipality_Contact_First_Name = cont.FirstName,
                     Municipality_Contact_Initial = cont.Initial,
                     Municipality_Contact_Last_Name = cont.LastName,
                     Municipality_Contact_Full_Name = (cont.FirstName + " " + (cont.Initial != null && cont.Initial != "" ? cont.Initial + ". " : "") + cont.LastName),
                     Municipality_Contact_Title = (ContactTitleEnum?)cont.ContactTitle,
                     Municipality_Contact_Tels = (tel == null ? ServiceRes.Empty : ((TelTypeEnum)tel.TelType).ToString() + ", " + tel.TelNumber),
                     Municipality_Contact_Emails = (email == null ? ServiceRes.Empty : ((EmailTypeEnum)email.EmailType).ToString() + ", " + email.EmailAddress),
                     Municipality_Contact_Civic_Address = (addr == null ? ServiceRes.Empty : (Language == LanguageEnum.fr
                     ? addr.StreetNumber + " " + addr.StreetName + " " + addr.StreetTypeText +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode : addr.StreetNumber + " " + addr.StreetTypeText + " " + addr.StreetName +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode)),
                     Municipality_Contact_Google_Address = (addr == null ? ServiceRes.Empty : addr.GoogleAddressText),
                     Municipality_Contact_Last_Update_Date_And_Time_UTC = t.LastUpdateDate_UTC,
                     Municipality_Contact_Last_Update_Contact_Name = contact.contactName,
                     Municipality_Contact_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportMunicipality_ContactModelQ =
                (from c in db.TVItems
                 from t in db.TVItemLinks
                 from cont in db.Contacts
                 let email = (from c in db.TVItemLinks
                              from t in db.Emails
                              where c.ToTVItemID == t.EmailTVItemID
                              && c.FromTVItemID == cont.ContactTVItemID
                              && c.FromTVType == (int)TVTypeEnum.Contact
                              && c.ToTVType == (int)TVTypeEnum.Email
                              select t).FirstOrDefault()
                 let tel = (from c in db.TVItemLinks
                            from t in db.Tels
                            where c.ToTVItemID == t.TelTVItemID
                            && c.FromTVItemID == cont.ContactTVItemID
                            && c.FromTVType == (int)TVTypeEnum.Contact
                            && c.ToTVType == (int)TVTypeEnum.Tel
                            select t).FirstOrDefault()
                 let addr = (from c in db.Addresses
                             let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)Language select cl.TVText).FirstOrDefault<string>()
                             let mip = (from mi in db.MapInfos
                                        from mip in db.MapInfoPoints
                                        where mi.MapInfoID == mip.MapInfoID
                                        && mi.TVItemID == c.AddressTVItemID
                                        && mi.TVType == (int)TVTypeEnum.Address
                                        && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                        select mip).FirstOrDefault()
                             where c.AddressTVItemID == t.ToTVItemID
                             select new AddressModel
                             {
                                 Error = "",
                                 AddressID = c.AddressID,
                                 AddressTVItemID = c.AddressTVItemID,
                                 AddressTVText = "",
                                 AddressType = (AddressTypeEnum)c.AddressType,
                                 AddressTypeText = "",
                                 MunicipalityTVItemID = c.MunicipalityTVItemID,
                                 MunicipalityTVText = muni,
                                 ProvinceTVItemID = c.ProvinceTVItemID,
                                 ProvinceTVText = prov,
                                 CountryTVItemID = c.CountryTVItemID,
                                 CountryTVText = country,
                                 StreetName = c.StreetName,
                                 StreetNumber = c.StreetNumber,
                                 StreetType = (StreetTypeEnum)c.StreetType,
                                 StreetTypeText = "",
                                 PostalCode = c.PostalCode,
                                 GoogleAddressText = c.GoogleAddressText,
                                 LatLngText = mip.Lat + " " + mip.Lng,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                             }).FirstOrDefault<AddressModel>()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == t.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == t.FromTVItemID
                 && t.FromTVType == (int)TVTypeEnum.Municipality
                 && t.ToTVType == (int)TVTypeEnum.Contact
                 && c.TVType == (int)TVTypeEnum.Municipality
                 && cont.ContactTVItemID == t.ToTVItemID
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportMunicipality_ContactModel
                 {
                     Municipality_Contact_Error = "",
                     Municipality_Contact_Counter = 0,
                     Municipality_Contact_ID = t.ToTVItemID,
                     Municipality_Contact_First_Name = cont.FirstName,
                     Municipality_Contact_Initial = cont.Initial,
                     Municipality_Contact_Last_Name = cont.LastName,
                     Municipality_Contact_Full_Name = (cont.FirstName + " " + (cont.Initial != null && cont.Initial != "" ? cont.Initial + ". " : "") + cont.LastName),
                     Municipality_Contact_Title = (ContactTitleEnum?)cont.ContactTitle,
                     Municipality_Contact_Tels = (tel == null ? ServiceRes.Empty : ((TelTypeEnum)tel.TelType).ToString() + ", " + tel.TelNumber),
                     Municipality_Contact_Emails = (email == null ? ServiceRes.Empty : ((EmailTypeEnum)email.EmailType).ToString() + ", " + email.EmailAddress),
                     Municipality_Contact_Civic_Address = (addr == null ? ServiceRes.Empty : (Language == LanguageEnum.fr
                     ? addr.StreetNumber + " " + addr.StreetName + " " + addr.StreetTypeText +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode : addr.StreetNumber + " " + addr.StreetTypeText + " " + addr.StreetName +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode)),
                     Municipality_Contact_Google_Address = (addr == null ? ServiceRes.Empty : addr.GoogleAddressText),
                     Municipality_Contact_Last_Update_Date_And_Time_UTC = t.LastUpdateDate_UTC,
                     Municipality_Contact_Last_Update_Contact_Name = contact.contactName,
                     Municipality_Contact_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportMunicipality_ContactModelQ = ReportServiceGeneratedMunicipality_Contact(reportMunicipality_ContactModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Counter = reportMunicipality_ContactModelQ.Count() } };

                reportMunicipality_ContactModelList = reportMunicipality_ContactModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMunicipality_ContactModel>() { new ReportMunicipality_ContactModel() { Municipality_Contact_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMunicipality_ContactModel reportMunicipality_ContactModel in reportMunicipality_ContactModelList)
            {
                Counter += 1;
                reportMunicipality_ContactModel.Municipality_Contact_Counter = Counter;
            }

            return reportMunicipality_ContactModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}