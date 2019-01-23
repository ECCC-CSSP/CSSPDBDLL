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
    public partial class ReportServiceSubsector_Climate_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Climate_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Climate_SiteModel> GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelList = new List<ReportSubsector_Climate_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Climate_Site";
            int Counter = 0;
            IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                    return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Subsector.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Climate_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Subsector)
            {
                reportSubsector_Climate_SiteModelQ =
                 (from c in db.TVItems
                  from cl in db.TVItemLanguages
                  from u in db.UseOfSites
                  from cs in db.ClimateSites
                  let mp = (from m in db.MapInfos
                            from mp in db.MapInfoPoints
                            where m.MapInfoID == mp.MapInfoID
                            && m.TVItemID == cs.ClimateSiteTVItemID
                            && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                            select mp).FirstOrDefault()
                  let contact = (from cc in db.Contacts
                                 let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                 let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                 where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                 select new { contactName, contactInitial }).FirstOrDefault()
                  where c.TVItemID == u.SiteTVItemID
                  && u.SiteTVItemID == cs.ClimateSiteTVItemID
                  && c.TVItemID == cl.TVItemID
                  && u.TVType == (int)TVTypeEnum.ClimateSite
                  && cl.Language == (int)Language
                  && u.SubsectorTVItemID == UnderTVItemID
                  select new ReportSubsector_Climate_SiteModel
                  {
                      Subsector_Climate_Site_Error = "",
                      Subsector_Climate_Site_Counter = 0,
                      Subsector_Climate_Site_ID = cs.ClimateSiteTVItemID,
                      Subsector_Climate_Site_Climate_ID = cs.ClimateID,
                      Subsector_Climate_Site_Name = cl.TVText,
                      Subsector_Climate_Site_Daily_End_Date_Local = cs.DailyStartDate_Local,
                      Subsector_Climate_Site_Daily_Now = cs.DailyNow,
                      Subsector_Climate_Site_Daily_Start_Date_Local = cs.DailyStartDate_Local,
                      Subsector_Climate_Site_ECDBID = cs.ECDBID,
                      Subsector_Climate_Site_Elevation_m = (float?)cs.Elevation_m,
                      Subsector_Climate_Site_File_desc = cs.File_desc,
                      Subsector_Climate_Site_Hourly_End_Date_Local = cs.HourlyEndDate_Local,
                      Subsector_Climate_Site_Hourly_Now = cs.HourlyNow,
                      Subsector_Climate_Site_Hourly_Start_Date_Local = cs.HourlyStartDate_Local,
                      Subsector_Climate_Site_Is_Provincial = cs.IsProvincial,
                      Subsector_Climate_Site_Last_Update_Date_UTC = cs.LastUpdateDate_UTC,
                      Subsector_Climate_Site_Monthly_End_Date_Local = cs.MonthlyEndDate_Local,
                      Subsector_Climate_Site_Monthly_Now = cs.MonthlyNow,
                      Subsector_Climate_Site_Monthly_Start_Date_Local = cs.MonthlyStartDate_Local,
                      Subsector_Climate_Site_Province = cs.Province,
                      Subsector_Climate_Site_Prov_Site_ID = cs.ProvSiteID,
                      Subsector_Climate_Site_TCID = cs.TCID,
                      Subsector_Climate_Site_Time_Offset_hour = (float?)cs.TimeOffset_hour,
                      Subsector_Climate_Site_WMOID = cs.WMOID,
                      Subsector_Climate_Site_Last_Update_Contact_Name = contact.contactName,
                      Subsector_Climate_Site_Last_Update_Contact_Initial = contact.contactInitial,
                      Subsector_Climate_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                      Subsector_Climate_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                  });
            }
            else
            {
                reportSubsector_Climate_SiteModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from u in db.UseOfSites
                 from cs in db.ClimateSites
                 from cu in db.TVItems
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == cs.ClimateSiteTVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == u.SiteTVItemID
                 && u.SiteTVItemID == cs.ClimateSiteTVItemID
                 && cu.TVItemID == u.SubsectorTVItemID
                 && c.TVItemID == cl.TVItemID
                 && u.TVType == (int)TVTypeEnum.ClimateSite
                 && cl.Language == (int)Language
                 && cu.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportSubsector_Climate_SiteModel
                 {
                     Subsector_Climate_Site_Error = "",
                     Subsector_Climate_Site_Counter = 0,
                     Subsector_Climate_Site_ID = cs.ClimateSiteTVItemID,
                     Subsector_Climate_Site_Climate_ID = cs.ClimateID,
                     Subsector_Climate_Site_Name = cl.TVText,
                     Subsector_Climate_Site_Daily_End_Date_Local = cs.DailyStartDate_Local,
                     Subsector_Climate_Site_Daily_Now = cs.DailyNow,
                     Subsector_Climate_Site_Daily_Start_Date_Local = cs.DailyStartDate_Local,
                     Subsector_Climate_Site_ECDBID = cs.ECDBID,
                     Subsector_Climate_Site_Elevation_m = (float?)cs.Elevation_m,
                     Subsector_Climate_Site_File_desc = cs.File_desc,
                     Subsector_Climate_Site_Hourly_End_Date_Local = cs.HourlyEndDate_Local,
                     Subsector_Climate_Site_Hourly_Now = cs.HourlyNow,
                     Subsector_Climate_Site_Hourly_Start_Date_Local = cs.HourlyStartDate_Local,
                     Subsector_Climate_Site_Is_Provincial = cs.IsProvincial,
                     Subsector_Climate_Site_Last_Update_Date_UTC = cs.LastUpdateDate_UTC,
                     Subsector_Climate_Site_Monthly_End_Date_Local = cs.MonthlyEndDate_Local,
                     Subsector_Climate_Site_Monthly_Now = cs.MonthlyNow,
                     Subsector_Climate_Site_Monthly_Start_Date_Local = cs.MonthlyStartDate_Local,
                     Subsector_Climate_Site_Province = cs.Province,
                     Subsector_Climate_Site_Prov_Site_ID = cs.ProvSiteID,
                     Subsector_Climate_Site_TCID = cs.TCID,
                     Subsector_Climate_Site_Time_Offset_hour = (float?)cs.TimeOffset_hour,
                     Subsector_Climate_Site_WMOID = cs.WMOID,
                     Subsector_Climate_Site_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Climate_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Subsector_Climate_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Subsector_Climate_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 });
            }

            try
            {
                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site(reportSubsector_Climate_SiteModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Counter = reportSubsector_Climate_SiteModelQ.Count() } };

                reportSubsector_Climate_SiteModelList = reportSubsector_Climate_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_Climate_SiteModel>() { new ReportSubsector_Climate_SiteModel() { Subsector_Climate_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_Climate_SiteModel reportSubsector_Climate_SiteModel in reportSubsector_Climate_SiteModelList)
            {
                Counter += 1;
                reportSubsector_Climate_SiteModel.Subsector_Climate_Site_Counter = Counter;
            }

            return reportSubsector_Climate_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}