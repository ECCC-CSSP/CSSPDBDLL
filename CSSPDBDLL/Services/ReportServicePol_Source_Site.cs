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
    public partial class ReportServicePol_Source_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServicePol_Source_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportPol_Source_SiteModel> GetReportPol_Source_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportPol_Source_SiteModel> reportPol_Source_SiteModelList = new List<ReportPol_Source_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Pol_Source_Site";
            int Counter = 0;
            IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.PolSourceSite)
                    return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.PolSourceSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportPol_Source_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = retStr } };

            string Pol_Source_Site_Last_Obs_Issue_Filtering = "";
            ReportTreeNode reportTreeNodeFiltering = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Last_Obs_Issue_Filtering").FirstOrDefault();
            if (reportTreeNodeFiltering != null)
            {
                if (reportTreeNodeFiltering.dbFilteringTextFieldList.Count > 0)
                {
                    Pol_Source_Site_Last_Obs_Issue_Filtering = reportTreeNodeFiltering.dbFilteringTextFieldList[0].TextCondition;
                }
            }

            int? Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level = null;
            ReportTreeNode reportTreeNodeStartLevel = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level").FirstOrDefault();
            if (reportTreeNodeStartLevel != null)
            {
                if (reportTreeNodeStartLevel.dbFilteringNumberFieldList.Count > 0)
                {
                    Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level = (int)reportTreeNodeStartLevel.dbFilteringNumberFieldList[0].NumberCondition;
                }
            }

            int? Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level = null;
            ReportTreeNode reportTreeNodeEndLevel = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level").FirstOrDefault();
            if (reportTreeNodeEndLevel != null)
            {
                if (reportTreeNodeEndLevel.dbFilteringNumberFieldList.Count > 0)
                {
                    Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level = (int)reportTreeNodeEndLevel.dbFilteringNumberFieldList[0].NumberCondition;
                }
            }

            if (Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level != null && Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level == null)
            {
                return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = string.Format(ServiceRes._IsRequired, "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level") } };
            }

            if (Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level == null && Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level != null)
            {
                return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = string.Format(ServiceRes._IsRequired, "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level") } };
            }

            if (Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level != null && Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level != null)
            {
                if ((int)Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level > (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level)
                {
                    return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = string.Format(ServiceRes._ShouldBeMoreThan_, "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level", "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level") } };
                }
            }

            bool? Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal = null;
            ReportTreeNode reportTreeNodeReverseEqual = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal").FirstOrDefault();
            if (reportTreeNodeReverseEqual != null)
            {
                if (reportTreeNodeReverseEqual.dbFilteringTrueFalseFieldList.Count > 0)
                {
                    if (reportTreeNodeReverseEqual.dbFilteringTrueFalseFieldList[0].ReportCondition == ReportConditionEnum.ReportConditionTrue)
                    {
                        Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal = true;
                    }
                    else
                    {
                        Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal = false;
                    }
                }
            }

            if (Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal != null && Pol_Source_Site_Last_Obs_Issue_Filtering.Length == 0)
            {
                return new List<ReportPol_Source_SiteModel>()
                { new ReportPol_Source_SiteModel()
                    {
                        Pol_Source_Site_Error = string.Format(ServiceRes.ToUse_YouNeed_NotToBeEmpty,
                        "Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal", "Pol_Source_Site_Last_Obs_Issue_Filtering")
                    }
                };
            }

            PolSourceIssueRiskEnum Pol_Source_Site_Last_Obs_Issue_Risk = PolSourceIssueRiskEnum.Error;
            ReportTreeNode reportTreeNodeRisk = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Last_Obs_Issue_Risk").FirstOrDefault();
            if (reportTreeNodeRisk != null)
            {
                if (reportTreeNodeRisk.dbFilteringEnumFieldList.Count > 0)
                {
                    string tempCondition = reportTreeNodeRisk.dbFilteringEnumFieldList[0].EnumConditionText;
                    switch (tempCondition)
                    {
                        case "HighRisk":
                            {
                                Pol_Source_Site_Last_Obs_Issue_Risk = PolSourceIssueRiskEnum.HighRisk;
                            }
                            break;
                        case "ModerateRisk":
                            {
                                Pol_Source_Site_Last_Obs_Issue_Risk = PolSourceIssueRiskEnum.ModerateRisk;
                            }
                            break;
                        case "LowRisk":
                            {
                                Pol_Source_Site_Last_Obs_Issue_Risk = PolSourceIssueRiskEnum.LowRisk;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            if (tvItem.TVType == (int)TVTypeEnum.PolSourceSite)
            {
                reportPol_Source_SiteModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from p in db.PolSourceSites
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == c.TVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
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
                             where c.AddressTVItemID == p.CivicAddressTVItemID
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
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == p.PolSourceSiteTVItemID
                 && c.TVType == (int)TVTypeEnum.PolSourceSite
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportPol_Source_SiteModel
                 {
                     Pol_Source_Site_Error = "",
                     Pol_Source_Site_Counter = 0,
                     Pol_Source_Site_ID = c.TVItemID,
                     Pol_Source_Site_Name = cl.TVText,
                     Pol_Source_Site_Last_Obs_Issue_Item_Text = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level = Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level,
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level = Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level,
                     Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal = Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal,
                     Pol_Source_Site_Last_Obs_Issue_Risk = Pol_Source_Site_Last_Obs_Issue_Risk,
                     Pol_Source_Site_Last_Obs_Issue_Filtering = Pol_Source_Site_Last_Obs_Issue_Filtering,
                     Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Sentence = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = "",
                     Pol_Source_Site_Is_Active = c.IsActive,
                     Pol_Source_Site_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Pol_Source_Site_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Pol_Source_Site_Last_Update_Contact_Name = contact.contactName,
                     Pol_Source_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Pol_Source_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Pol_Source_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Pol_Source_Site_Old_Site_Id = p.Oldsiteid,
                     Pol_Source_Site_Site_ID = p.SiteID,
                     Pol_Source_Site_Site = p.Site,
                     Pol_Source_Site_Is_Point_Source = p.IsPointSource,
                     Pol_Source_Site_Inactive_Reason = (PolSourceInactiveReasonEnum?)p.InactiveReason,
                     Pol_Source_Site_Civic_Address = (addr == null ? ServiceRes.Empty : (Language == LanguageEnum.fr
                     ? addr.StreetNumber + " " + addr.StreetName + " " + addr.StreetTypeText +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode : addr.StreetNumber + " " + addr.StreetTypeText + " " + addr.StreetName +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode)),
                     Pol_Source_Site_Google_Address = (addr == null ? ServiceRes.Empty : addr.GoogleAddressText),
                 });
            }
            else
            {
                reportPol_Source_SiteModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from p in db.PolSourceSites
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == c.TVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
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
                             where c.AddressTVItemID == p.CivicAddressTVItemID
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
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == p.PolSourceSiteTVItemID
                 && c.TVType == (int)TVTypeEnum.PolSourceSite
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportPol_Source_SiteModel
                 {
                     Pol_Source_Site_Error = "",
                     Pol_Source_Site_Counter = 0,
                     Pol_Source_Site_ID = c.TVItemID,
                     Pol_Source_Site_Name = cl.TVText,
                     Pol_Source_Site_Last_Obs_Issue_Item_Text = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level = Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level,
                     Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level = Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level,
                     Pol_Source_Site_Last_Obs_Issue_Risk = Pol_Source_Site_Last_Obs_Issue_Risk,
                     Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal = Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal,
                     Pol_Source_Site_Last_Obs_Issue_Filtering = Pol_Source_Site_Last_Obs_Issue_Filtering,
                     Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial = "",
                     Pol_Source_Site_Last_Obs_Issue_Sentence = "",
                     Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = "",
                     Pol_Source_Site_Is_Active = c.IsActive,
                     Pol_Source_Site_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Pol_Source_Site_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Pol_Source_Site_Last_Update_Contact_Name = contact.contactName,
                     Pol_Source_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Pol_Source_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Pol_Source_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Pol_Source_Site_Old_Site_Id = p.Oldsiteid,
                     Pol_Source_Site_Site_ID = p.SiteID,
                     Pol_Source_Site_Site = p.Site,
                     Pol_Source_Site_Is_Point_Source = p.IsPointSource,
                     Pol_Source_Site_Inactive_Reason = (PolSourceInactiveReasonEnum?)p.InactiveReason,
                     Pol_Source_Site_Civic_Address = (addr == null ? ServiceRes.Empty : (Language == LanguageEnum.fr
                     ? addr.StreetNumber + " " + addr.StreetName + " " + addr.StreetTypeText +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode : addr.StreetNumber + " " + addr.StreetTypeText + " " + addr.StreetName +
                        " " + addr.MunicipalityTVText + " " + addr.ProvinceTVText + " " + addr.CountryTVText +
                        " " + addr.PostalCode)),
                     Pol_Source_Site_Google_Address = (addr == null ? ServiceRes.Empty : addr.GoogleAddressText),
                 });
            }

            try
            {
                reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site(reportPol_Source_SiteModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = retStr } };

                if (CountOnly)
                    return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Counter = reportPol_Source_SiteModelQ.Count() } };

                reportPol_Source_SiteModelList = reportPol_Source_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportPol_Source_SiteModel>() { new ReportPol_Source_SiteModel() { Pol_Source_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            List<string> PolSourceObsInfoEqualList = new List<string>();
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringTextFieldList.Count > 0
            && c.Text == "Pol_Source_Site_Last_Obs_Issue_Filtering"))
            {
                foreach (ReportConditionTextField reportTextField in reportTreeNode.dbFilteringTextFieldList)
                {
                    if (reportTextField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                    {
                        List<string> PolSourceObsInfoTextList = reportTextField.TextCondition.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                        foreach (string s in PolSourceObsInfoTextList)
                        {
                            bool Found = false;
                            foreach (PolSourceObsInfoEnum polSourceObsInfo in Enum.GetValues(typeof(PolSourceObsInfoEnum)))
                            {
                                if (polSourceObsInfo.ToString() == s)
                                {
                                    PolSourceObsInfoEqualList.Add(((int)polSourceObsInfo).ToString());
                                    Found = true;
                                }
                            }

                            if (!Found)
                                PolSourceObsInfoEqualList.Add(PolSourceObsInfoEnum.Error.ToString());
                        }
                    }
                }
            }

            foreach (ReportPol_Source_SiteModel reportPol_Source_SiteModel in reportPol_Source_SiteModelList)
            {
                PolSourceObservation polSourceObservationLast = (from c in db.PolSourceObservations
                                                                 where c.PolSourceSiteID == (from pp in db.PolSourceSites
                                                                                             where pp.PolSourceSiteTVItemID == reportPol_Source_SiteModel.Pol_Source_Site_ID
                                                                                             select pp.PolSourceSiteID).FirstOrDefault()
                                                                 orderby c.ObservationDate_Local descending
                                                                 select c).FirstOrDefault();

                List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                if (polSourceObservationLast != null)
                {
                    polSourceObservationIssueList = (from c in db.PolSourceObservationIssues
                                                     where c.PolSourceObservationID == polSourceObservationLast.PolSourceObservationID
                                                     orderby c.Ordinal ascending
                                                     select c).ToList();
                }

                // check if one of the Issue contain ",91" or ",92" or ",93" --> Risk

                bool ContainRisk = (from c in polSourceObservationIssueList
                                    where (c.ObservationInfo.Contains(",91")
                                    || c.ObservationInfo.Contains(",92")
                                    || c.ObservationInfo.Contains(",93"))
                                    select c).Any();

                if (!ContainRisk)
                {
                    if (polSourceObservationLast != null)
                    {
                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = ServiceRes.WrittenDescription + " : " + polSourceObservationLast.Observation_ToBeDeleted;
                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence = ServiceRes.WrittenDescription + " : " + polSourceObservationLast.Observation_ToBeDeleted;
                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = polSourceObservationIssueList[0].ObservationInfo;
                    }
                    else
                    {
                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = ServiceRes.WrittenDescription + " : " + ServiceRes.Empty;
                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence = ServiceRes.WrittenDescription + " : " + ServiceRes.Empty;
                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = ServiceRes.Empty;
                    }
                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial = "";
                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial = "";
                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial = "";
                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text = "";
                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial = "";
                }
                else
                {
                    foreach (PolSourceObservationIssue polSourceObservationIssue in polSourceObservationIssueList)
                    {
                        bool EqualRisk = false;
                        if (Pol_Source_Site_Last_Obs_Issue_Risk != PolSourceIssueRiskEnum.Error)
                        {
                            if (Pol_Source_Site_Last_Obs_Issue_Risk == PolSourceIssueRiskEnum.HighRisk
                                && (polSourceObservationIssue.ObservationInfo.Contains(",93001")
                                || polSourceObservationIssue.ObservationInfo.Contains(",92002")))
                            {
                                EqualRisk = true;
                            }
                            else if (Pol_Source_Site_Last_Obs_Issue_Risk == PolSourceIssueRiskEnum.ModerateRisk
                                && polSourceObservationIssue.ObservationInfo.Contains(",92001"))
                            {
                                EqualRisk = true;
                            }
                            else if (Pol_Source_Site_Last_Obs_Issue_Risk == PolSourceIssueRiskEnum.LowRisk
                                && polSourceObservationIssue.ObservationInfo.Contains(",91001"))
                            {
                                EqualRisk = true;
                            }
                            else
                            {
                                // nothing
                            }
                        }
                        else
                        {
                            EqualRisk = true;
                        }

                        if (PolSourceObsInfoEqualList.Count > 0)
                        {
                            int countEqualFound = 0;
                            int countReverseEqualFound = 0;
                            foreach (string s in PolSourceObsInfoEqualList)
                            {
                                if (polSourceObservationIssue.ObservationInfo.Contains(s))
                                {
                                    countEqualFound += 1;
                                }

                                if (!polSourceObservationIssue.ObservationInfo.Contains(s))
                                {
                                    countReverseEqualFound += 1;
                                }
                            }

                            if (Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal != null && Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == true)
                            {
                                if (countReverseEqualFound == PolSourceObsInfoEqualList.Count)
                                {
                                    if (EqualRisk)
                                    {
                                        if (string.IsNullOrWhiteSpace(reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence))
                                        {
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence = GetPolSourceObsIssueSentence(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, 0, 1000);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial = GetPolSourceObsIssueSelectionFirstInitial(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial = GetPolSourceObsIssueSelectionSecondInitial(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial = GetPolSourceObsIssueSelectionLastInitial(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text = GetPolSourceObsIssueSelectionRisk(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial = GetPolSourceObsIssueSelectionRiskInitial(polSourceObservationIssue.ObservationInfo);
                                            if (Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level != null && Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level != null)
                                            {
                                                reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level, (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (countEqualFound == PolSourceObsInfoEqualList.Count)
                                {
                                    if (EqualRisk)
                                    {
                                        if (string.IsNullOrWhiteSpace(reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence))
                                        {
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence = GetPolSourceObsIssueSentence(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, 0, 1000);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial = GetPolSourceObsIssueSelectionFirstInitial(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial = GetPolSourceObsIssueSelectionSecondInitial(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial = GetPolSourceObsIssueSelectionLastInitial(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text = GetPolSourceObsIssueSelectionRisk(polSourceObservationIssue.ObservationInfo);
                                            reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial = GetPolSourceObsIssueSelectionRiskInitial(polSourceObservationIssue.ObservationInfo);
                                            if (Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level != null
                                                && Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level != null)
                                            {
                                                reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level, (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (EqualRisk)
                            {
                                if (string.IsNullOrWhiteSpace(reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence))
                                {
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Sentence = GetPolSourceObsIssueSentence(polSourceObservationIssue.ObservationInfo);
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, 0, 1000);
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial = GetPolSourceObsIssueSelectionFirstInitial(polSourceObservationIssue.ObservationInfo);
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial = GetPolSourceObsIssueSelectionSecondInitial(polSourceObservationIssue.ObservationInfo);
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial = GetPolSourceObsIssueSelectionLastInitial(polSourceObservationIssue.ObservationInfo);
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text = GetPolSourceObsIssueSelectionRisk(polSourceObservationIssue.ObservationInfo);
                                    reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial = GetPolSourceObsIssueSelectionRiskInitial(polSourceObservationIssue.ObservationInfo);
                                    if (Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level != null
                                        && Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level != null)
                                    {
                                        reportPol_Source_SiteModel.Pol_Source_Site_Last_Obs_Issue_Item_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level, (int)Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            reportPol_Source_SiteModelList = reportPol_Source_SiteModelList.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence != "").ToList();

            foreach (ReportPol_Source_SiteModel reportPol_Source_SiteModel in reportPol_Source_SiteModelList)
            {
                Counter += 1;
                reportPol_Source_SiteModel.Pol_Source_Site_Counter = Counter;
            }

            return reportPol_Source_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}