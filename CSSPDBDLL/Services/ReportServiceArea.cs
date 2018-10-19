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
    public partial class ReportServiceArea : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceArea(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportAreaModel> GetReportAreaModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportAreaModel> reportAreaModelList = new List<ReportAreaModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Area";
            int Counter = 0;
            IQueryable<ReportAreaModel> reportAreaModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Area)
                    return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Area.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Area)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportAreaModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Area)
            {
                reportAreaModelList =
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
                     && c.TVType == (int)TVTypeEnum.Area
                     && cl.Language == (int)Language
                     && c.TVItemID == UnderTVItemID
                     select new ReportAreaModel
                     {
                         Area_Error = "",
                         Area_Counter = 0,
                         Area_ID = c.TVItemID,
                         Area_Is_Active = c.IsActive,
                         Area_Last_Update_Contact_Name = contact.contactName,
                         Area_Last_Update_Contact_Initial = contact.contactInitial,
                         Area_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         Area_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         Area_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         Area_Name_Short = (cl.TVText.Contains(" ") ? cl.TVText.Substring(0, cl.TVText.IndexOf(" ")) : cl.TVText),
                         Area_Name_Long = cl.TVText,
                         Area_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     }).ToList();
            }
            else
            {
                reportAreaModelList =
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
                 && c.TVType == (int)TVTypeEnum.Area
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportAreaModel
                 {
                     Area_Error = "",
                     Area_Counter = 0,
                     Area_ID = c.TVItemID,
                     Area_Is_Active = c.IsActive,
                     Area_Last_Update_Contact_Name = contact.contactName,
                     Area_Last_Update_Contact_Initial = contact.contactInitial,
                     Area_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Area_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Area_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Area_Name_Long = cl.TVText,
                     Area_Name_Short = (cl.TVText.Contains(" ") ? cl.TVText.Substring(0, cl.TVText.IndexOf(" ")) : cl.TVText),
                     Area_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                 }).ToList();
            }

            foreach (ReportAreaModel reportAreaModel in reportAreaModelList)
            {
                tvItemStatList = (from st in db.TVItemStats
                                  where st.TVItemID == reportAreaModel.Area_ID
                                  select st).ToList();

                reportAreaModel.Area_Stat_Box_Model_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.BoxModel).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Lift_Station_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.LiftStation).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Mike_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MikeScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Municipality_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Municipality).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_MWQM_Run_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMRun).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_MWQM_Sample_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSiteSample).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_MWQM_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Pol_Source_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.PolSourceSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Sector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Sector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Subsector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Subsector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_Visual_Plumes_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.VisualPlumesScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportAreaModel.Area_Stat_WWTP_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
            }

            try
            {
                reportAreaModelQ = reportAreaModelList.AsQueryable();
                reportAreaModelQ = ReportServiceGeneratedArea(reportAreaModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Error = retStr } };

                if (CountOnly)
                    return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Counter = reportAreaModelQ.Count() } };

                reportAreaModelList = reportAreaModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportAreaModel>() { new ReportAreaModel() { Area_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportAreaModel reportAreaModel in reportAreaModelList)
            {
                Counter += 1;
                reportAreaModel.Area_Counter = Counter;
            }

            return reportAreaModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}