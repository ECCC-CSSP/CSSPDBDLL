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
    public partial class ReportServiceMWQM_Site : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Site(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_SiteModel> GetReportMWQM_SiteModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_SiteModel> reportMWQM_SiteModelList = new List<ReportMWQM_SiteModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Site";
            int Counter = 0;
            IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMSite)
                    return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_SiteModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MWQMSite)
            {
                reportMWQM_SiteModelQ =
                    (from c in db.TVItems
                     from cl in db.TVItemLanguages
                     from m in db.MWQMSites
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
                     && c.TVItemID == m.MWQMSiteTVItemID
                     && c.TVType == (int)TVTypeEnum.MWQMSite
                     && cl.Language == (int)Language
                     && c.TVItemID == UnderTVItemID
                     select new ReportMWQM_SiteModel
                     {
                         MWQM_Site_Error = "",
                         MWQM_Site_Counter = 0,
                         MWQM_Site_ID = c.TVItemID,
                         MWQM_Site_Name = cl.TVText,
                         MWQM_Site_Is_Active = c.IsActive,
                         MWQM_Site_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                         MWQM_Site_Number = m.MWQMSiteNumber,
                         MWQM_Site_Description = m.MWQMSiteDescription,
                         MWQM_Site_Latest_Classification = (MWQMSiteLatestClassificationEnum)m.MWQMSiteLatestClassification,
                         MWQM_Site_Ordinal = m.Ordinal,
                         MWQM_Site_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         MWQM_Site_Last_Update_Contact_Name = contact.contactName,
                         MWQM_Site_Last_Update_Contact_Initial = contact.contactInitial,
                         MWQM_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         MWQM_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         MWQM_Site_Stat_MWQM_Run_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMRun select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         MWQM_Site_Stat_MWQM_Sample_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSiteSample select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         MWQM_Site_Stat_X_Last_Samples = 0,
                         MWQM_Site_Stat_GM_X_Last_Samples = 0,
                         MWQM_Site_Stat_Median_X_Last_Samples = 0,
                         MWQM_Site_Stat_P90_X_Last_Samples = 0,
                         MWQM_Site_Stat_Perc_Over_43_X_Last_Samples = 0,
                         MWQM_Site_Stat_Perc_Over_260_X_Last_Samples = 0,
                         MWQM_Site_Stat_Min_Year_X_Last_Samples = 0,
                         MWQM_Site_Stat_Max_Year_X_Last_Samples = 0,
                         MWQM_Site_Stat_Sample_Count_X_Last_Samples = 0,
                         MWQM_Site_Stat_Min_FC_X_Last_Samples = 0,
                         MWQM_Site_Stat_Max_FC_X_Last_Samples = 0
                     });
            }
            else
            {
                reportMWQM_SiteModelQ =
                    (from c in db.TVItems
                     from cl in db.TVItemLanguages
                     from m in db.MWQMSites
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
                     && c.TVItemID == m.MWQMSiteTVItemID
                     && c.TVType == (int)TVTypeEnum.MWQMSite
                     && cl.Language == (int)Language
                     && c.TVPath.StartsWith(tvItem.TVPath + "p")
                     select new ReportMWQM_SiteModel
                     {
                         MWQM_Site_Error = "",
                         MWQM_Site_Counter = 0,
                         MWQM_Site_ID = c.TVItemID,
                         MWQM_Site_Name = cl.TVText,
                         MWQM_Site_Is_Active = c.IsActive,
                         MWQM_Site_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                         MWQM_Site_Number = m.MWQMSiteNumber,
                         MWQM_Site_Description = m.MWQMSiteDescription,
                         MWQM_Site_Latest_Classification = (MWQMSiteLatestClassificationEnum)m.MWQMSiteLatestClassification,
                         MWQM_Site_Ordinal = m.Ordinal,
                         MWQM_Site_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                         MWQM_Site_Last_Update_Contact_Name = contact.contactName,
                         MWQM_Site_Last_Update_Contact_Initial = contact.contactInitial,
                         MWQM_Site_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                         MWQM_Site_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                         MWQM_Site_Stat_MWQM_Run_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMRun select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         MWQM_Site_Stat_MWQM_Sample_Count = (from c in stat where c.TVType == (int)TVTypeEnum.MWQMSiteSample select c.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                         MWQM_Site_Stat_X_Last_Samples = 0,
                         MWQM_Site_Stat_GM_X_Last_Samples = 0,
                         MWQM_Site_Stat_Median_X_Last_Samples = 0,
                         MWQM_Site_Stat_P90_X_Last_Samples = 0,
                         MWQM_Site_Stat_Perc_Over_43_X_Last_Samples = 0,
                         MWQM_Site_Stat_Perc_Over_260_X_Last_Samples = 0,
                         MWQM_Site_Stat_Min_Year_X_Last_Samples = 0,
                         MWQM_Site_Stat_Max_Year_X_Last_Samples = 0,
                         MWQM_Site_Stat_Sample_Count_X_Last_Samples = 0,
                         MWQM_Site_Stat_Min_FC_X_Last_Samples = 0,
                         MWQM_Site_Stat_Max_FC_X_Last_Samples = 0
                     });
            }

            try
            {
                reportMWQM_SiteModelList = reportMWQM_SiteModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_SiteModel reportMWQM_SiteModel in reportMWQM_SiteModelList)
            {
                List<string> StatList = new List<string>()
                {
                    "MWQM_Site_Stat_GM_X_Last_Samples", "MWQM_Site_Stat_Median_X_Last_Samples", "MWQM_Site_Stat_P90_X_Last_Samples",
                    "MWQM_Site_Stat_Perc_Over_43_X_Last_Samples", "MWQM_Site_Stat_Perc_Over_260_X_Last_Samples",
                    "MWQM_Site_Stat_Min_FC_X_Last_Samples", "MWQM_Site_Stat_Max_FC_X_Last_Samples", "MWQM_Site_Stat_Min_Year_X_Last_Samples",
                    "MWQM_Site_Stat_Max_Year_X_Last_Samples", "MWQM_Site_Stat_Sample_Count_X_Last_Samples"
                };

                if (reportTreeNodeList.Where(c => StatList.Contains(c.Text)).Any())
                {
                    ReportTreeNode reportTreeNodeXSamples = reportTreeNodeList.Where(c => c.Text == "MWQM_Site_Stat_X_Last_Samples").FirstOrDefault();

                    if (reportTreeNodeXSamples == null)
                        return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = string.Format(ServiceRes._IsRequired, "MWQM_Site_Stat_X_Last_Samples") } };

                    if (reportTreeNodeXSamples.dbFilteringNumberFieldList.Count == 0)
                        return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = string.Format(ServiceRes._IsRequired, "Database Filtering EQUAL") + " for MWQM_Site_Stat_X_Last_Samples" } };

                    if (reportTreeNodeXSamples.dbFilteringNumberFieldList.Count > 1)
                        return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = string.Format(ServiceRes.OnlyOne_IsAllowed, "Database Filtering EQUAL") + " for MWQM_Site_Stat_X_Last_Samples" } };

                    int NumberOfSamples = (int)reportTreeNodeXSamples.dbFilteringNumberFieldList[0].NumberCondition.Value;
                    reportMWQM_SiteModel.MWQM_Site_Stat_X_Last_Samples = NumberOfSamples;

                    List<MWQMSample> mwqmSampleList = (from w in db.MWQMSites
                                                       from s in db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == reportMWQM_SiteModel.MWQM_Site_ID
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    int SampCount = mwqmSampleList.Count();
                    int MinFC = 0;
                    int MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);

                        reportMWQM_SiteModel.MWQM_Site_Stat_Min_FC_X_Last_Samples = MinFC;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Max_FC_X_Last_Samples = MaxFC;

                        if (mwqmSampleList.Count >= 4)
                        {
                            List<double> GeoMeanList = (from c in mwqmSampleList
                                                        orderby c.FecCol_MPN_100ml
                                                        select (double)c.FecCol_MPN_100ml).ToList<double>();

                            reportMWQM_SiteModel.MWQM_Site_Stat_P90_X_Last_Samples = (float)_TVItemService.GetP90(GeoMeanList);
                            reportMWQM_SiteModel.MWQM_Site_Stat_GM_X_Last_Samples = (float)_TVItemService.GeometricMean(GeoMeanList);
                            reportMWQM_SiteModel.MWQM_Site_Stat_Median_X_Last_Samples = (float)_TVItemService.GetMedian(GeoMeanList);
                            reportMWQM_SiteModel.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                            reportMWQM_SiteModel.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                            reportMWQM_SiteModel.MWQM_Site_Stat_Min_Year_X_Last_Samples = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Max_Year_X_Last_Samples = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Sample_Count_X_Last_Samples = mwqmSampleList.Count;
                        }
                        else
                        {
                            reportMWQM_SiteModel.MWQM_Site_Stat_P90_X_Last_Samples = -1.0f;
                            reportMWQM_SiteModel.MWQM_Site_Stat_GM_X_Last_Samples = -1.0f;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Median_X_Last_Samples = -1.0f;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples = -1.0f;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples = -1.0f;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Min_Year_X_Last_Samples = -1;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Max_Year_X_Last_Samples = -1;
                            reportMWQM_SiteModel.MWQM_Site_Stat_Sample_Count_X_Last_Samples = -1;
                        }
                    }
                    else
                    {
                        reportMWQM_SiteModel.MWQM_Site_Stat_P90_X_Last_Samples = -1.0f;
                        reportMWQM_SiteModel.MWQM_Site_Stat_GM_X_Last_Samples = -1.0f;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Median_X_Last_Samples = -1.0f;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples = -1.0f;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples = -1.0f;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Min_Year_X_Last_Samples = -1;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Sample_Count_X_Last_Samples = -1;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Min_FC_X_Last_Samples = -1;
                        reportMWQM_SiteModel.MWQM_Site_Stat_Max_FC_X_Last_Samples = -1;
                    }
                }

            }

            reportMWQM_SiteModelQ = reportMWQM_SiteModelList.AsQueryable();
            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site(reportMWQM_SiteModelQ, reportTreeNodeList);
            ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
            retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = retStr } };

            try
            {
                if (CountOnly)
                    return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Counter = reportMWQM_SiteModelQ.Count() } };

                reportMWQM_SiteModelList = reportMWQM_SiteModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_SiteModel>() { new ReportMWQM_SiteModel() { MWQM_Site_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_SiteModel reportMWQM_SiteModel in reportMWQM_SiteModelList)
            {
                Counter += 1;
                reportMWQM_SiteModel.MWQM_Site_Counter = Counter;
            }

            return reportMWQM_SiteModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}