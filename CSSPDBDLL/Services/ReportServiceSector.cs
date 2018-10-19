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
    public partial class ReportServiceSector : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSector(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSectorModel> GetReportSectorModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSectorModel> reportSectorModelList = new List<ReportSectorModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Sector";
            int Counter = 0;
            IQueryable<ReportSectorModel> reportSectorModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Sector)
                    return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Sector.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Sector)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSectorModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Sector)
            {
                reportSectorModelQ =
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
                 let stat = (from s in db.TVItemStats
                             where s.TVItemID == c.TVItemID
                             select s)
                 where c.TVItemID == cl.TVItemID
                 && c.TVType == (int)TVTypeEnum.Sector
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportSectorModel
                 {
                     Sector_Error = "",
                     Sector_Counter = 0,
                     Sector_ID = c.TVItemID,
                     Sector_Is_Active = c.IsActive,
                     Sector_Last_Update_Contact_Name = contact.contactName,
                     Sector_Last_Update_Contact_Initial = contact.contactInitial,
                     Sector_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Sector_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Sector_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Sector_Name_Short = (cl.TVText.Contains(" ") ? cl.TVText.Substring(0, cl.TVText.IndexOf(" ")) : cl.TVText),
                     Sector_Name_Long = cl.TVText,
                     Sector_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Sector_Stat_Box_Model_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.BoxModel select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Lift_Station_Count = (from c in stat where c.TVType == (int)TVTypeEnum.LiftStation select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Mike_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MikeScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Municipality_Count = (from c in stat where c.TVType == (int)TVTypeEnum.Municipality select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_MWQM_Run_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMRun select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_MWQM_Sample_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSiteSample select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_MWQM_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Pol_Source_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.PolSourceSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Subsector_Count = (from c in stat where c.TVType == (int)TVTypeEnum.Subsector select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Visual_Plumes_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.VisualPlumesScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_WWTP_Count = (from c in stat where c.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                 });
            }
            else
            {
                reportSectorModelQ =
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
                 let stat = (from s in db.TVItemStats
                             where s.TVItemID == c.TVItemID
                             select s)
                 where c.TVItemID == cl.TVItemID
                 && c.TVType == (int)TVTypeEnum.Sector
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportSectorModel
                 {
                     Sector_Error = "",
                     Sector_Counter = 0,
                     Sector_ID = c.TVItemID,
                     Sector_Is_Active = c.IsActive,
                     Sector_Last_Update_Contact_Name = contact.contactName,
                     Sector_Last_Update_Contact_Initial = contact.contactInitial,
                     Sector_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Sector_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Sector_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Sector_Name_Short = (cl.TVText.Contains(" ") ? cl.TVText.Substring(0, cl.TVText.IndexOf(" ")) : cl.TVText),
                     Sector_Name_Long = cl.TVText,
                     Sector_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Sector_Stat_Box_Model_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.BoxModel select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Lift_Station_Count = (from c in stat where c.TVType == (int)TVTypeEnum.LiftStation select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Mike_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MikeScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Municipality_Count = (from c in stat where c.TVType == (int)TVTypeEnum.Municipality select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_MWQM_Run_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMRun select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_MWQM_Sample_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSiteSample select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_MWQM_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Pol_Source_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.PolSourceSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Subsector_Count = (from c in stat where c.TVType == (int)TVTypeEnum.Subsector select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_Visual_Plumes_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.VisualPlumesScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Sector_Stat_WWTP_Count = (from c in stat where c.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                 });
            }

            try
            {
                reportSectorModelQ = ReportServiceGeneratedSector(reportSectorModelQ, reportTreeNodeList.Where(c => c.Text != "Sector_Counter").ToList());
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Counter = reportSectorModelQ.Count() } };

                reportSectorModelList = reportSectorModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSectorModel>() { new ReportSectorModel() { Sector_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSectorModel reportSectorModel in reportSectorModelList)
            {
                Counter += 1;
                reportSectorModel.Sector_Counter = Counter;
            }

            return reportSectorModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}