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
    public partial class ReportServiceSubsector_Tide_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Tide_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Tide_SiteModel> GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelList = new List<ReportSubsector_Tide_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Tide_Site";
            int Counter = 0;
            IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                    return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Subsector.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Subsector)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Tide_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Subsector)
            {
                reportSubsector_Tide_SiteModelQ =
                 (from c in db.TVItems
                  from cl in db.TVItemLanguages
                  from u in db.UseOfSites
                  from cs in db.TideSites
                  let mp = (from m in db.MapInfos
                            from mp in db.MapInfoPoints
                            where m.MapInfoID == mp.MapInfoID
                            && m.TVItemID == cs.TideSiteTVItemID
                            && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                            select mp).FirstOrDefault()
                  let contact = (from cc in db.Contacts
                                 let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                 let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                 where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                 select new { contactName, contactInitial }).FirstOrDefault()
                  where c.TVItemID == u.SiteTVItemID
                  && u.SiteTVItemID == cs.TideSiteTVItemID
                  && c.TVItemID == cl.TVItemID
                  && u.TVType == (int)TVTypeEnum.TideSite
                  && cl.Language == (int)Language
                  && u.SubsectorTVItemID == UnderTVItemID
                  select new ReportSubsector_Tide_SiteModel
                  {
                      Subsector_Tide_Site_Error = "",
                      Subsector_Tide_Site_Counter = 0,
                      Subsector_Tide_Site_ID = cs.TideSiteTVItemID,
                      Subsector_Tide_Site_Name_Translation_Status = (TranslationStatusEnum?)cl.TranslationStatus,
                      Subsector_Tide_Site_Name = cl.TVText,
                      Subsector_Tide_Site_Is_Active = c.IsActive,
                      Subsector_Tide_Site_Province = cs.Province,
                      Subsector_Tide_Site_sid = cs.sid,
                      Subsector_Tide_Site_Zone = cs.Zone,
                      Subsector_Tide_Site_Last_Update_Date_And_Time_UTC = cs.LastUpdateDate_UTC,
                      Subsector_Tide_Site_Last_Update_Contact_Name = contact.contactName,
                      Subsector_Tide_Site_Last_Update_Contact_Initial = contact.contactInitial,
                      Subsector_Tide_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                      Subsector_Tide_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                  });
            }
            else
            {
                reportSubsector_Tide_SiteModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from u in db.UseOfSites
                 from cs in db.TideSites
                 from cu in db.TVItems
                 let mp = (from m in db.MapInfos
                           from mp in db.MapInfoPoints
                           where m.MapInfoID == mp.MapInfoID
                           && m.TVItemID == cs.TideSiteTVItemID
                           && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                           select mp).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == u.SiteTVItemID
                 && u.SiteTVItemID == cs.TideSiteTVItemID
                 && c.TVItemID == cl.TVItemID
                 && u.TVType == (int)TVTypeEnum.TideSite
                 && cl.Language == (int)Language
                 && cu.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportSubsector_Tide_SiteModel
                 {
                     Subsector_Tide_Site_Error = "",
                     Subsector_Tide_Site_Counter = 0,
                     Subsector_Tide_Site_ID = cs.TideSiteTVItemID,
                     Subsector_Tide_Site_Name_Translation_Status = (TranslationStatusEnum?)cl.TranslationStatus,
                     Subsector_Tide_Site_Name = cl.TVText,
                     Subsector_Tide_Site_Is_Active = c.IsActive,
                     Subsector_Tide_Site_Province = cs.Province,
                     Subsector_Tide_Site_sid = cs.sid,
                     Subsector_Tide_Site_Zone = cs.Zone,
                     Subsector_Tide_Site_Last_Update_Date_And_Time_UTC = cs.LastUpdateDate_UTC,
                     Subsector_Tide_Site_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Tide_Site_Last_Update_Contact_Initial = contact.contactInitial,
                     Subsector_Tide_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                     Subsector_Tide_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                 });
            }

            try
            {
                reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site(reportSubsector_Tide_SiteModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Counter = reportSubsector_Tide_SiteModelQ.Count() } };

                reportSubsector_Tide_SiteModelList = reportSubsector_Tide_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_Tide_SiteModel>() { new ReportSubsector_Tide_SiteModel() { Subsector_Tide_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_Tide_SiteModel reportSubsector_Tide_SiteModel in reportSubsector_Tide_SiteModelList)
            {
                Counter += 1;
                reportSubsector_Tide_SiteModel.Subsector_Tide_Site_Counter = Counter;
            }

            return reportSubsector_Tide_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}