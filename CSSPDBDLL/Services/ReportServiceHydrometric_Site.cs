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
    public partial class ReportServiceHydrometric_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceHydrometric_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportHydrometric_SiteModel> GetReportHydrometric_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportHydrometric_SiteModel> reportHydrometric_SiteModelList = new List<ReportHydrometric_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Hydrometric_Site";
            int Counter = 0;
            IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.HydrometricSite)
                    return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.HydrometricSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.HydrometricSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportHydrometric_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.HydrometricSite)
            {
                reportHydrometric_SiteModelQ =
                 (from c in db.TVItems
                  from cl in db.TVItemLanguages
                  from h in db.HydrometricSites
                  let mp = (from m in db.MapInfos
                            from mp in db.MapInfoPoints
                            where m.MapInfoID == mp.MapInfoID
                            && m.TVItemID == h.HydrometricSiteTVItemID
                            && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                            select mp).FirstOrDefault()
                  let contact = (from cc in db.Contacts
                                 let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                 let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                 where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                 select new { contactName, contactInitial }).FirstOrDefault()
                  where c.TVItemID == cl.TVItemID
                  && c.TVItemID == h.HydrometricSiteTVItemID
                  && c.TVType == (int)TVTypeEnum.HydrometricSite
                  && cl.Language == (int)Language
                  && c.TVItemID == UnderTVItemID
                  select new ReportHydrometric_SiteModel
                  {
                      Hydrometric_Site_Error = "",
                      Hydrometric_Site_Counter = 0,
                      Hydrometric_Site_ID = h.HydrometricSiteTVItemID,
                      Hydrometric_Site_Fed_Site_Number = h.FedSiteNumber,
                      Hydrometric_Site_Quebec_Site_Number = h.QuebecSiteNumber,
                      Hydrometric_Site_Name = cl.TVText,
                      Hydrometric_Site_Description = h.Description,
                      Hydrometric_Site_Province = h.Province,
                      Hydrometric_Site_Elevation_m = (float?)h.Elevation_m,
                      Hydrometric_Site_Start_Date_Local = h.StartDate_Local,
                      Hydrometric_Site_End_Date_Local = h.EndDate_Local,
                      Hydrometric_Site_Time_Offset_hour = (float?)h.TimeOffset_hour,
                      Hydrometric_Site_Drainage_Area_km2 = (float?)h.DrainageArea_km2,
                      Hydrometric_Site_Is_Natural = h.IsNatural,
                      Hydrometric_Site_Is_Active = h.IsActive,
                      Hydrometric_Site_Sediment = h.Sediment,
                      Hydrometric_Site_RHBN = h.RHBN,
                      Hydrometric_Site_Real_Time = h.RealTime,
                      Hydrometric_Site_Has_Rating_Curve = h.HasRatingCurve,
                      Hydrometric_Site_Last_Update_Date_UTC = h.LastUpdateDate_UTC,
                      Hydrometric_Site_Last_Update_Contact_Name = contact.contactName,
                      Hydrometric_Site_Last_Update_Contact_Initial = contact.contactInitial,
                      Hydrometric_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                      Hydrometric_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                  });
            }
            else
            {
                reportHydrometric_SiteModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from h in db.HydrometricSites
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == h.HydrometricSiteTVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == h.HydrometricSiteTVItemID
                 && c.TVType == (int)TVTypeEnum.HydrometricSite
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportHydrometric_SiteModel
                 {
                     Hydrometric_Site_Error = "",
                     Hydrometric_Site_Counter = 0,
                     Hydrometric_Site_ID = h.HydrometricSiteTVItemID,
                     Hydrometric_Site_Fed_Site_Number = h.FedSiteNumber,
                     Hydrometric_Site_Quebec_Site_Number = h.QuebecSiteNumber,
                     Hydrometric_Site_Name = cl.TVText,
                     Hydrometric_Site_Description = h.Description,
                     Hydrometric_Site_Province = h.Province,
                     Hydrometric_Site_Elevation_m = (float?)h.Elevation_m,
                     Hydrometric_Site_Start_Date_Local = h.StartDate_Local,
                     Hydrometric_Site_End_Date_Local = h.EndDate_Local,
                     Hydrometric_Site_Time_Offset_hour = (float?)h.TimeOffset_hour,
                     Hydrometric_Site_Drainage_Area_km2 = (float?)h.DrainageArea_km2,
                     Hydrometric_Site_Is_Natural = h.IsNatural,
                     Hydrometric_Site_Is_Active = h.IsActive,
                     Hydrometric_Site_Sediment = h.Sediment,
                     Hydrometric_Site_RHBN = h.RHBN,
                     Hydrometric_Site_Real_Time = h.RealTime,
                     Hydrometric_Site_Has_Rating_Curve = h.HasRatingCurve,
                     Hydrometric_Site_Last_Update_Date_UTC = h.LastUpdateDate_UTC,
                     Hydrometric_Site_Last_Update_Contact_Name = contact.contactName,
                     Hydrometric_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Hydrometric_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Hydrometric_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 });
            }

            try
            {
                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site(reportHydrometric_SiteModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Error = retStr } };

                if (CountOnly)
                    return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Counter = reportHydrometric_SiteModelQ.Count() } };

                reportHydrometric_SiteModelList = reportHydrometric_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportHydrometric_SiteModel>() { new ReportHydrometric_SiteModel() { Hydrometric_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportHydrometric_SiteModel reportHydrometric_SiteModel in reportHydrometric_SiteModelList)
            {
                Counter += 1;
                reportHydrometric_SiteModel.Hydrometric_Site_Counter = Counter;
            }

            return reportHydrometric_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}