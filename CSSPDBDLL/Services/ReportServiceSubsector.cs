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
    public partial class ReportServiceSubsector : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsectorModel> GetReportSubsectorModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsectorModel> reportSubsectorModelList = new List<ReportSubsectorModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector";
            int Counter = 0;
            IQueryable<ReportSubsectorModel> reportSubsectorModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                    return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Subsector.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsectorModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Subsector)
            {
                reportSubsectorModelQ =
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
                 && c.TVType == (int)TVTypeEnum.Subsector
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportSubsectorModel
                 {
                     Subsector_Error = "",
                     Subsector_Counter = 0,
                     Subsector_ID = c.TVItemID,
                     Subsector_Is_Active = c.IsActive,
                     Subsector_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Last_Update_Contact_Initial = contact.contactInitial,
                     Subsector_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Subsector_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Subsector_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Subsector_Name_Short = (cl.TVText.Contains(" ") ? cl.TVText.Substring(0, cl.TVText.IndexOf(" ")) : cl.TVText),
                     Subsector_Name_Long = cl.TVText,
                     Subsector_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Subsector_Stat_Box_Model_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.BoxModel select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Lift_Station_Count = (from c in stat where c.TVType == (int)TVTypeEnum.LiftStation select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Mike_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MikeScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Municipality_Count = (from c in stat where c.TVType == (int)TVTypeEnum.Municipality select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_MWQM_Run_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMRun select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_MWQM_Sample_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSiteSample select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_MWQM_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Pol_Source_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.PolSourceSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Visual_Plumes_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.VisualPlumesScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_WWTP_Count = (from c in stat where c.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                 });
            }
            else
            {
                reportSubsectorModelQ =
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
                 && c.TVType == (int)TVTypeEnum.Subsector
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportSubsectorModel
                 {
                     Subsector_Error = "",
                     Subsector_Counter = 0,
                     Subsector_ID = c.TVItemID,
                     Subsector_Is_Active = c.IsActive,
                     Subsector_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Last_Update_Contact_Initial = contact.contactInitial,
                     Subsector_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                     Subsector_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Subsector_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                     Subsector_Name_Short = (cl.TVText.Contains(" ") ? cl.TVText.Substring(0, cl.TVText.IndexOf(" ")) : cl.TVText),
                     Subsector_Name_Long = cl.TVText,
                     Subsector_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Subsector_Stat_Box_Model_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.BoxModel select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Lift_Station_Count = (from c in stat where c.TVType == (int)TVTypeEnum.LiftStation select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Mike_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MikeScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Municipality_Count = (from c in stat where c.TVType == (int)TVTypeEnum.Municipality select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_MWQM_Run_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMRun select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_MWQM_Sample_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSiteSample select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_MWQM_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Pol_Source_Site_Count = (from c in stat where c.TVType == (int)TVTypeEnum.PolSourceSite select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_Visual_Plumes_Scenario_Count = (from c in stat where c.TVType == (int)TVTypeEnum.VisualPlumesScenario select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     Subsector_Stat_WWTP_Count = (from c in stat where c.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                 });
            }

            try
            {
                reportSubsectorModelQ = ReportServiceGeneratedSubsector(reportSubsectorModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Counter = reportSubsectorModelQ.Count() } };

                reportSubsectorModelList = reportSubsectorModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsectorModel>() { new ReportSubsectorModel() { Subsector_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsectorModel reportSubsectorModel in reportSubsectorModelList)
            {
                Counter += 1;
                reportSubsectorModel.Subsector_Counter = Counter;
            }

            return reportSubsectorModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}