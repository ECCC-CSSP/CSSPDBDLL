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
    public partial class ReportServiceCountry : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceCountry(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportCountryModel> GetReportCountryModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportCountryModel> reportCountryModelList = new List<ReportCountryModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Country";
            int Counter = 0;
            IQueryable<ReportCountryModel> reportCountryModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Country)
                    return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Country.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Country)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportCountryModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Country)
            {
                reportCountryModelList =
                     (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      let mp = (from m in db.MapInfos
                                from mp in db.MapInfoPoints
                                where m.MapInfoID == mp.MapInfoID
                                && m.TVItemID == c.TVItemID
                                && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                select mp).FirstOrDefault()
                      let contact = (from cc in db.Contacts
                                     let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                     let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                     where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                     select new { contactName, contactInitial }).FirstOrDefault()
                      where c.TVItemID == cl.TVItemID
                      && c.TVType == (int)TVTypeEnum.Country
                      && cl.Language == (int)Language
                      && c.TVItemID == UnderTVItemID
                      select new ReportCountryModel
                      {
                          Country_Error = "",
                          Country_Counter = 0,
                          Country_ID = c.TVItemID,
                          Country_Is_Active = c.IsActive,
                          Country_Last_Update_Contact_Name = contact.contactName,
                          Country_Last_Update_Contact_Initial = contact.contactInitial,
                          Country_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                          Country_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                          Country_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                          Country_Name = cl.TVText,
                          Country_Initial = (cl.TVText.Contains("Unis") || cl.TVText.Contains("United") ? (Language == LanguageEnum.fr ? "ÉU" : "US") : "CA"),
                          Country_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                      }).ToList();

            }
            else
            {
                reportCountryModelList =
                    (from c in db.TVItems
                     from cl in db.TVItemLanguages
                     let mp = (from m in db.MapInfos
                               from mp in db.MapInfoPoints
                               where m.MapInfoID == mp.MapInfoID
                               && m.TVItemID == c.TVItemID
                               && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                               select mp).FirstOrDefault()
                     let contact = (from cc in db.Contacts
                                    let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                    let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                    where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                    select new { contactName, contactInitial }).FirstOrDefault()
                     where c.TVItemID == cl.TVItemID
                     && c.TVType == (int)TVTypeEnum.Country
                     && cl.Language == (int)Language
                     && c.TVPath.StartsWith(tvItem.TVPath + "p")
                     select new ReportCountryModel
                     {
                         Country_Error = "",
                         Country_Counter = 0,
                         Country_ID = c.TVItemID,
                         Country_Is_Active = c.IsActive,
                         Country_Last_Update_Contact_Name = contact.contactName,
                         Country_Last_Update_Contact_Initial = contact.contactInitial,
                         Country_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         Country_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         Country_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         Country_Name = cl.TVText,
                         Country_Initial = (cl.TVText.Contains("Unis") || cl.TVText.Contains("United") ? (Language == LanguageEnum.fr ? "ÉU" : "US") : "CA"),
                         Country_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     }).ToList();
            }

            foreach (ReportCountryModel reportCountryModel in reportCountryModelList)
            {
                tvItemStatList = (from st in db.TVItemStats
                                  where st.TVItemID == reportCountryModel.Country_ID
                                  select st).ToList();

                reportCountryModel.Country_Stat_Area_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Area).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Province_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Province).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Box_Model_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.BoxModel).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Lift_Station_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.LiftStation).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Mike_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MikeScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Municipality_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Municipality).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_MWQM_Run_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMRun).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_MWQM_Sample_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSiteSample).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_MWQM_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Pol_Source_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.PolSourceSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Sector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Sector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Subsector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Subsector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_Visual_Plumes_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.VisualPlumesScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportCountryModel.Country_Stat_WWTP_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
            }

            try
            {
                reportCountryModelQ = reportCountryModelList.AsQueryable();
                reportCountryModelQ = ReportServiceGeneratedCountry(reportCountryModelQ, reportTreeNodeList.Where(c => c.Text != "Country_Counter").ToList());
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Error = retStr } };

                if (CountOnly)
                    return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Counter = reportCountryModelQ.Count() } };

                reportCountryModelList = reportCountryModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportCountryModel>() { new ReportCountryModel() { Country_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportCountryModel reportCountryModel in reportCountryModelList)
            {
                Counter += 1;
                reportCountryModel.Country_Counter = Counter;
            }

            return reportCountryModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}