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
    public partial class ReportServiceClimate_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceClimate_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportClimate_SiteModel> GetReportClimate_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportClimate_SiteModel> reportClimate_SiteModelList = new List<ReportClimate_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Climate_Site";
            int Counter = 0;
            IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.ClimateSite)
                    return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.ClimateSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.ClimateSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportClimate_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.ClimateSite)
            {
                reportClimate_SiteModelQ =
                (from c in db.ClimateSites
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == c.ClimateSiteTVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == c.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.ClimateSiteTVItemID == UnderTVItemID
                 select new ReportClimate_SiteModel
                 {
                     Climate_Site_Error = "",
                     Climate_Site_Counter = 0,
                     Climate_Site_ID = c.ClimateSiteTVItemID,
                     Climate_Site_Climate_ID = c.ClimateID,
                     Climate_Site_Name = c.ClimateSiteName,
                     Climate_Site_Daily_End_Date_Local = c.DailyStartDate_Local,
                     Climate_Site_Daily_Now = c.DailyNow,
                     Climate_Site_Daily_Start_Date_Local = c.DailyStartDate_Local,
                     Climate_Site_ECDBID = c.ECDBID,
                     Climate_Site_Elevation_m = (float?)c.Elevation_m,
                     Climate_Site_File_desc = c.File_desc,
                     Climate_Site_Hourly_End_Date_Local = c.HourlyEndDate_Local,
                     Climate_Site_Hourly_Now = c.HourlyNow,
                     Climate_Site_Hourly_Start_Date_Local = c.HourlyStartDate_Local,
                     Climate_Site_Is_Provincial = c.IsProvincial,
                     Climate_Site_Last_Update_Date_UTC = c.LastUpdateDate_UTC,
                     Climate_Site_Monthly_End_Date_Local = c.MonthlyEndDate_Local,
                     Climate_Site_Monthly_Now = c.MonthlyNow,
                     Climate_Site_Monthly_Start_Date_Local = c.MonthlyStartDate_Local,
                     Climate_Site_Province = c.Province,
                     Climate_Site_Prov_Site_ID = c.ProvSiteID,
                     Climate_Site_TCID = c.TCID,
                     Climate_Site_Time_Offset_hour = (float?)c.TimeOffset_hour,
                     Climate_Site_WMOID = c.WMOID,
                     Climate_Site_Last_Update_Contact_Name = contact.contactName,
                     Climate_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Climate_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Climate_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 });
            }
            else
            {
                reportClimate_SiteModelQ =
                (from t in db.TVItems
                 from c in db.ClimateSites
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == c.ClimateSiteTVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == c.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where t.TVItemID == c.ClimateSiteTVItemID
                 && t.TVType == (int)TVTypeEnum.ClimateSite
                 && t.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportClimate_SiteModel
                 {
                     Climate_Site_Error = "",
                     Climate_Site_Counter = 0,
                     Climate_Site_ID = c.ClimateSiteTVItemID,
                     Climate_Site_Climate_ID = c.ClimateID,
                     Climate_Site_Name = c.ClimateSiteName,
                     Climate_Site_Daily_End_Date_Local = c.DailyStartDate_Local,
                     Climate_Site_Daily_Now = c.DailyNow,
                     Climate_Site_Daily_Start_Date_Local = c.DailyStartDate_Local,
                     Climate_Site_ECDBID = c.ECDBID,
                     Climate_Site_Elevation_m = (float?)c.Elevation_m,
                     Climate_Site_File_desc = c.File_desc,
                     Climate_Site_Hourly_End_Date_Local = c.HourlyEndDate_Local,
                     Climate_Site_Hourly_Now = c.HourlyNow,
                     Climate_Site_Hourly_Start_Date_Local = c.HourlyStartDate_Local,
                     Climate_Site_Is_Provincial = c.IsProvincial,
                     Climate_Site_Last_Update_Date_UTC = c.LastUpdateDate_UTC,
                     Climate_Site_Monthly_End_Date_Local = c.MonthlyEndDate_Local,
                     Climate_Site_Monthly_Now = c.MonthlyNow,
                     Climate_Site_Monthly_Start_Date_Local = c.MonthlyStartDate_Local,
                     Climate_Site_Province = c.Province,
                     Climate_Site_Prov_Site_ID = c.ProvSiteID,
                     Climate_Site_TCID = c.TCID,
                     Climate_Site_Time_Offset_hour = (float?)c.TimeOffset_hour,
                     Climate_Site_WMOID = c.WMOID,
                     Climate_Site_Last_Update_Contact_Name = contact.contactName,
                     Climate_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Climate_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Climate_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 });
            }

            try
            {
                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site(reportClimate_SiteModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Error = retStr } };

                if (CountOnly)
                    return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Counter = reportClimate_SiteModelQ.Count() } };

                reportClimate_SiteModelList = reportClimate_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportClimate_SiteModel>() { new ReportClimate_SiteModel() { Climate_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportClimate_SiteModel reportClimate_SiteModel in reportClimate_SiteModelList)
            {
                Counter += 1;
                reportClimate_SiteModel.Climate_Site_Counter = Counter;
            }

            return reportClimate_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}