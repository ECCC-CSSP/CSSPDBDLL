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
    public partial class ReportServiceProvince : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceProvince(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportProvinceModel> GetReportProvinceModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportProvinceModel> reportProvinceModelList = new List<ReportProvinceModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Province";
            int Counter = 0;
            IQueryable<ReportProvinceModel> reportProvinceModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Province)
                    return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Province.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Province)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportProvinceModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Province)
            {
                reportProvinceModelList =
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
                      && c.TVType == (int)TVTypeEnum.Province
                      && cl.Language == (int)Language
                      && c.TVItemID == UnderTVItemID
                      select new ReportProvinceModel
                      {
                          Province_Error = "",
                          Province_Counter = 0,
                          Province_ID = c.TVItemID,
                          Province_Is_Active = c.IsActive,
                          Province_Last_Update_Contact_Name = contact.contactName,
                          Province_Last_Update_Contact_Initial = contact.contactInitial,
                          Province_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                          Province_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                          Province_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                          Province_Name = cl.TVText,
                          Province_Initial = "",
                          Province_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                      }).ToList();

            }
            else
            {
                reportProvinceModelList =
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
                     && c.TVType == (int)TVTypeEnum.Province
                     && cl.Language == (int)Language
                     && c.TVPath.StartsWith(tvItem.TVPath + "p")
                     select new ReportProvinceModel
                     {
                         Province_Error = "",
                         Province_Counter = 0,
                         Province_ID = c.TVItemID,
                         Province_Is_Active = c.IsActive,
                         Province_Last_Update_Contact_Name = contact.contactName,
                         Province_Last_Update_Contact_Initial = contact.contactInitial,
                         Province_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         Province_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         Province_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         Province_Name = cl.TVText,
                         Province_Initial = "",
                         Province_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     }).ToList();

            }

            foreach (ReportProvinceModel reportProvinceModel in reportProvinceModelList)
            {
                tvItemStatList = (from st in db.TVItemStats
                                  where st.TVItemID == reportProvinceModel.Province_ID
                                  select st).ToList();

                reportProvinceModel.Province_Stat_Area_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Area).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Box_Model_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.BoxModel).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Lift_Station_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.LiftStation).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Mike_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MikeScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Municipality_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Municipality).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_MWQM_Run_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMRun).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_MWQM_Sample_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSiteSample).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_MWQM_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Pol_Source_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.PolSourceSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Sector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Sector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Subsector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Subsector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_Visual_Plumes_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.VisualPlumesScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportProvinceModel.Province_Stat_WWTP_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
            }

            try
            {
                reportProvinceModelQ = reportProvinceModelList.AsQueryable();
                reportProvinceModelQ = ReportServiceGeneratedProvince(reportProvinceModelQ, reportTreeNodeList.Where(c => c.Text != "Province_Counter").ToList());
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Error = retStr } };

                if (CountOnly)
                    return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Counter = reportProvinceModelQ.Count() } };

                reportProvinceModelList = reportProvinceModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportProvinceModel>() { new ReportProvinceModel() { Province_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportProvinceModel reportProvinceModel in reportProvinceModelList)
            {
                Counter += 1;
                reportProvinceModel.Province_Counter = Counter;
            }

            foreach (ReportProvinceModel reportProvinceModel in reportProvinceModelList)
            {
                if (Language == LanguageEnum.fr)
                {
                    switch (reportProvinceModel.Province_Name)
                    {
                        case "Colombie-Britannique":
                            reportProvinceModel.Province_Initial = "CB";
                            break;
                        case "Nouveau-Brunswick":
                            reportProvinceModel.Province_Initial = "NB";
                            break;
                        case "Terre-Neuve-et-Labrador":
                            reportProvinceModel.Province_Initial = "TL";
                            break;
                        case "Nouvelle-Écosse":
                            reportProvinceModel.Province_Initial = "NE";
                            break;
                        case "Île-du-Prince-Édouard":
                            reportProvinceModel.Province_Initial = "IPE";
                            break;
                        case "Québec":
                            reportProvinceModel.Province_Initial = "QC";
                            break;
                        case "Maine":
                            reportProvinceModel.Province_Initial = "ME";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (reportProvinceModel.Province_Name)
                    {
                        case "British Columbia":
                            reportProvinceModel.Province_Initial = "BC";
                            break;
                        case "New Brunswick":
                            reportProvinceModel.Province_Initial = "NB";
                            break;
                        case "Newfoundland and Labrador":
                            reportProvinceModel.Province_Initial = "NL";
                            break;
                        case "Nova Scotia":
                            reportProvinceModel.Province_Initial = "NS";
                            break;
                        case "Prince Edward Island":
                            reportProvinceModel.Province_Initial = "PEI";
                            break;
                        case "Québec":
                            reportProvinceModel.Province_Initial = "QC";
                            break;
                        case "Maine":
                            reportProvinceModel.Province_Initial = "ME";
                            break;
                        default:
                            break;
                    }
                }
            }

            return reportProvinceModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}