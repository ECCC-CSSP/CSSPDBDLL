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
    public partial class ReportServiceMunicipality : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMunicipality(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMunicipalityModel> GetReportMunicipalityModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportMunicipalityModel> reportMunicipalityModelList = new List<ReportMunicipalityModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Municipality";
            int Counter = 0;
            IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Municipality)
                    return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Municipality.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Municipality)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMunicipalityModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Municipality)
            {
                reportMunicipalityModelQ =
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
                     && c.TVType == (int)TVTypeEnum.Municipality
                     && cl.Language == (int)Language
                     && c.TVItemID == UnderTVItemID
                     select new ReportMunicipalityModel
                     {
                         Municipality_Error = "",
                         Municipality_Counter = 0,
                         Municipality_ID = c.TVItemID,
                         Municipality_Is_Active = c.IsActive,
                         Municipality_Last_Update_Contact_Name = contact.contactName,
                         Municipality_Last_Update_Contact_Initial = contact.contactInitial,
                         Municipality_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         Municipality_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         Municipality_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         Municipality_Name = cl.TVText,
                         Municipality_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                         Municipality_Stat_Box_Model_Scenario_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.BoxModel).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_Lift_Station_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.LiftStation).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_Mike_Scenario_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.MikeScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_Visual_Plumes_Scenario_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.VisualPlumesScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_WWTP_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     });
            }
            else
            {
                reportMunicipalityModelQ =
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
                     && c.TVType == (int)TVTypeEnum.Municipality
                     && cl.Language == (int)Language
                     && c.TVPath.StartsWith(tvItem.TVPath + "p")
                     select new ReportMunicipalityModel
                     {
                         Municipality_Error = "",
                         Municipality_Counter = 0,
                         Municipality_ID = c.TVItemID,
                         Municipality_Is_Active = c.IsActive,
                         Municipality_Last_Update_Contact_Name = contact.contactName,
                         Municipality_Last_Update_Contact_Initial = contact.contactInitial,
                         Municipality_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         Municipality_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         Municipality_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         Municipality_Name = cl.TVText,
                         Municipality_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                         Municipality_Stat_Box_Model_Scenario_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.BoxModel).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_Lift_Station_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.LiftStation).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_Mike_Scenario_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.MikeScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_Visual_Plumes_Scenario_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.VisualPlumesScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         Municipality_Stat_WWTP_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     });
            }

            try
            {
                reportMunicipalityModelQ = ReportServiceGeneratedMunicipality(reportMunicipalityModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Counter = reportMunicipalityModelQ.Count() } };

                reportMunicipalityModelList = reportMunicipalityModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMunicipalityModel>() { new ReportMunicipalityModel() { Municipality_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMunicipalityModel reportMunicipalityModel in reportMunicipalityModelList)
            {
                Counter += 1;
                reportMunicipalityModel.Municipality_Counter = Counter;
            }

            return reportMunicipalityModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}