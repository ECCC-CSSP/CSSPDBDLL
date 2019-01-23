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
    public partial class ReportServiceMWQM_Run_Sample : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Run_Sample(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_Run_SampleModel> GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_Run_SampleModel> reportMWQM_Run_SampleModelList = new List<ReportMWQM_Run_SampleModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Run_Sample";
            int Counter = 0;
            IQueryable<ReportMWQM_Run_SampleModel> reportMWQM_Run_SampleModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMRun)
                    return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMRun.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMRun)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_Run_SampleModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MWQMRun)
            {
                reportMWQM_Run_SampleModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.MWQMSamples
                 from sl in db.MWQMSampleLanguages
                 let siteName = (from tl in db.TVItemLanguages
                                 where tl.TVItemID == s.MWQMSiteTVItemID
                                 && tl.Language == (int)Language
                                 select tl.TVText).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMRunTVItemID
                 && s.MWQMSampleID == sl.MWQMSampleID
                 && c.TVType == (int)TVTypeEnum.MWQMRun
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 && sl.Language == (int)Language
                 select new ReportMWQM_Run_SampleModel
                 {
                     MWQM_Run_Sample_Error = "",
                     MWQM_Run_Sample_Counter = 0,
                     MWQM_Run_Sample_ID = s.MWQMSampleID,
                     MWQM_Run_Sample_Date_Time_Local = s.SampleDateTime_Local,
                     MWQM_Run_Sample_Depth_m = (float?)s.Depth_m,
                     MWQM_Run_Sample_Fec_Col_MPN_100_ml = (int)s.FecCol_MPN_100ml,
                     MWQM_Run_Sample_Salinity_PPT = (float?)s.Salinity_PPT,
                     MWQM_Run_Sample_Water_Temp_C = (float?)s.WaterTemp_C,
                     MWQM_Run_Sample_PH = (float?)s.PH,
                     MWQM_Run_Sample_Types = s.SampleTypesText,
                     MWQM_Run_Sample_Tube_10 = (int?)s.Tube_10,
                     MWQM_Run_Sample_Tube_1_0 = (int?)s.Tube_1_0,
                     MWQM_Run_Sample_Tube_0_1 = (int?)s.Tube_0_1,
                     MWQM_Run_Sample_Processed_By = s.ProcessedBy,
                     MWQM_Run_Sample_Note_Translation_Status = (TranslationStatusEnum?)sl.TranslationStatus,
                     MWQM_Run_Sample_Note = sl.MWQMSampleNote,
                     MWQM_Run_Sample_Last_Update_Date_And_Time_UTC = s.LastUpdateDate_UTC,
                     MWQM_Run_Sample_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Run_Sample_Last_Update_Contact_Initial = contact.contactInitial,
                     MWQM_Run_Sample_MWQM_Site = (siteName == null ? ServiceRes.Empty : siteName),
                     MWQM_Run_Sample_Rain_Day_0_mm = -1,
                     MWQM_Run_Sample_Rain_Day_1_mm = -1,
                     MWQM_Run_Sample_Rain_Day_2_mm = -1,
                     MWQM_Run_Sample_Rain_Day_3_mm = -1,
                     MWQM_Run_Sample_Rain_Day_4_mm = -1,
                     MWQM_Run_Sample_Rain_Day_5_mm = -1,
                     MWQM_Run_Sample_Rain_Day_6_mm = -1,
                     MWQM_Run_Sample_Rain_Day_7_mm = -1,
                     MWQM_Run_Sample_Rain_Day_8_mm = -1,
                     MWQM_Run_Sample_Rain_Day_9_mm = -1,
                     MWQM_Run_Sample_Rain_Day_10_mm = -1,
                     MWQM_Run_Sample_Tide_Start = TideTextEnum.Error,
                     MWQM_Run_Sample_Tide_End = TideTextEnum.Error,
                 });
            }
            else
            {
                reportMWQM_Run_SampleModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.MWQMSamples
                 from sl in db.MWQMSampleLanguages
                 let siteName = (from tl in db.TVItemLanguages
                                 where tl.TVItemID == s.MWQMSiteTVItemID
                                 && tl.Language == (int)Language
                                 select tl.TVText).FirstOrDefault()
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMRunTVItemID
                 && s.MWQMSampleID == sl.MWQMSampleID
                 && c.TVType == (int)TVTypeEnum.MWQMRun
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 && sl.Language == (int)Language
                 select new ReportMWQM_Run_SampleModel
                 {
                     MWQM_Run_Sample_Error = "",
                     MWQM_Run_Sample_Counter = 0,
                     MWQM_Run_Sample_ID = s.MWQMSampleID,
                     MWQM_Run_Sample_Date_Time_Local = s.SampleDateTime_Local,
                     MWQM_Run_Sample_Depth_m = (float?)s.Depth_m,
                     MWQM_Run_Sample_Fec_Col_MPN_100_ml = (int)s.FecCol_MPN_100ml,
                     MWQM_Run_Sample_Salinity_PPT = (float?)s.Salinity_PPT,
                     MWQM_Run_Sample_Water_Temp_C = (float?)s.WaterTemp_C,
                     MWQM_Run_Sample_PH = (float?)s.PH,
                     MWQM_Run_Sample_Types = s.SampleTypesText,
                     MWQM_Run_Sample_Tube_10 = (int?)s.Tube_10,
                     MWQM_Run_Sample_Tube_1_0 = (int?)s.Tube_1_0,
                     MWQM_Run_Sample_Tube_0_1 = (int?)s.Tube_0_1,
                     MWQM_Run_Sample_Processed_By = s.ProcessedBy,
                     MWQM_Run_Sample_Note_Translation_Status = (TranslationStatusEnum?)sl.TranslationStatus,
                     MWQM_Run_Sample_Note = sl.MWQMSampleNote,
                     MWQM_Run_Sample_Last_Update_Date_And_Time_UTC = s.LastUpdateDate_UTC,
                     MWQM_Run_Sample_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Run_Sample_Last_Update_Contact_Initial = contact.contactInitial,
                     MWQM_Run_Sample_MWQM_Site = (siteName == null ? ServiceRes.Empty : siteName),
                     MWQM_Run_Sample_Rain_Day_1_mm = null,
                     MWQM_Run_Sample_Rain_Day_2_mm = null,
                     MWQM_Run_Sample_Rain_Day_3_mm = null,
                     MWQM_Run_Sample_Tide_Start = null,
                     MWQM_Run_Sample_Tide_End = null,
                 });
            }

            try
            {
                reportMWQM_Run_SampleModelQ = ReportServiceGeneratedMWQM_Run_Sample(reportMWQM_Run_SampleModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Counter = reportMWQM_Run_SampleModelQ.Count() } };

                reportMWQM_Run_SampleModelList = reportMWQM_Run_SampleModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_Run_SampleModel>() { new ReportMWQM_Run_SampleModel() { MWQM_Run_Sample_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_Run_SampleModel reportMWQM_Run_SampleModel in reportMWQM_Run_SampleModelList)
            {
                if (reportTreeNodeList.Where(c => c.Text == "MWQM_Run_Sample_Types").Any())
                {
                    List<string> NumbTextList = reportMWQM_Run_SampleModel.MWQM_Run_Sample_Types.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + ", ";
                    }
                    reportMWQM_Run_SampleModel.MWQM_Run_Sample_Types = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }
            }

            foreach (ReportMWQM_Run_SampleModel reportMWQM_Run_SampleModel in reportMWQM_Run_SampleModelList)
            {
                Counter += 1;
                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Counter = Counter;

                if (reportMWQM_Run_SampleModel.MWQM_Run_Sample_Date_Time_Local.HasValue)
                {
                    DateTime SampleDate = new DateTime(reportMWQM_Run_SampleModel.MWQM_Run_Sample_Date_Time_Local.Value.Year, reportMWQM_Run_SampleModel.MWQM_Run_Sample_Date_Time_Local.Value.Month, reportMWQM_Run_SampleModel.MWQM_Run_Sample_Date_Time_Local.Value.Day);
                    DateTime SampleDate24 = SampleDate.AddDays(-1);
                    DateTime SampleDate48 = SampleDate.AddDays(-2);
                    DateTime SampleDate72 = SampleDate.AddDays(-3);

                    List<ClimateDataValue> climateDataValueList = (from r in db.MWQMRuns
                                                                   from s in db.MWQMSamples
                                                                   from c in db.ClimateDataValues
                                                                   from cs in db.ClimateSites
                                                                   from u in db.UseOfSites
                                                                   where r.MWQMRunTVItemID == s.MWQMRunTVItemID
                                                                   && u.SubsectorTVItemID == r.SubsectorTVItemID
                                                                   && cs.ClimateSiteTVItemID == u.SiteTVItemID
                                                                   && c.ClimateSiteID == cs.ClimateSiteID
                                                                   && c.DateTime_Local <= SampleDate24
                                                                   && c.DateTime_Local >= SampleDate72
                                                                   && u.TVType == (int)TVTypeEnum.ClimateSite
                                                                   && (c.RainfallEntered_mm != null || c.TotalPrecip_mm_cm != null)
                                                                   && s.MWQMSampleID == reportMWQM_Run_SampleModel.MWQM_Run_Sample_ID
                                                                   orderby c.DateTime_Local descending
                                                                   select c).ToList();

                    foreach (ClimateDataValue climateDataValue in climateDataValueList)
                    {
                        DateTime climateDate = new DateTime(climateDataValue.DateTime_Local.Year, climateDataValue.DateTime_Local.Month, climateDataValue.DateTime_Local.Day);
                        
                        // 24 hours
                        if (SampleDate24 == climateDate)
                        {
                            if (climateDataValue.RainfallEntered_mm != null)
                            {
                                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_1_mm = (float?)climateDataValue.RainfallEntered_mm;
                            }
                            else
                            {
                                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_1_mm = (float?)climateDataValue.TotalPrecip_mm_cm;
                            }
                        }

                        // 48 hours
                        if (SampleDate48 == climateDate)
                        {
                            if (climateDataValue.RainfallEntered_mm != null)
                            {
                                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_2_mm = reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_1_mm + (float?)climateDataValue.RainfallEntered_mm;
                            }
                            else
                            {
                                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_2_mm = reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_1_mm + (float?)climateDataValue.TotalPrecip_mm_cm;
                            }
                        }

                        // 72 hours
                        if (SampleDate72 == climateDate)
                        {
                            if (climateDataValue.RainfallEntered_mm != null)
                            {
                                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_3_mm = reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_2_mm + (float ?)climateDataValue.RainfallEntered_mm;
                            }
                            else
                            {
                                reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_3_mm = reportMWQM_Run_SampleModel.MWQM_Run_Sample_Rain_Day_2_mm + (float ?)climateDataValue.TotalPrecip_mm_cm;
                            }
                        }
                    }

                    TideDataValue tideDataValue = (from r in db.MWQMRuns
                                                   from s in db.MWQMSamples
                                                   from t in db.TideDataValues
                                                   from cs in db.TideSites
                                                   from u in db.UseOfSites
                                                   where r.MWQMRunTVItemID == s.MWQMRunTVItemID
                                                   && u.SubsectorTVItemID == r.SubsectorTVItemID
                                                   && cs.TideSiteTVItemID == u.SiteTVItemID
                                                   && t.TideSiteTVItemID == cs.TideSiteTVItemID
                                                   && t.DateTime_Local == SampleDate
                                                   && u.TVType == (int)TVTypeEnum.TideSite
                                                   && s.MWQMSampleID == reportMWQM_Run_SampleModel.MWQM_Run_Sample_ID
                                                   && t.TideStart != (int)TideTextEnum.Error
                                                   && t.TideEnd != (int)TideTextEnum.Error
                                                   select t).FirstOrDefault();

                    if (tideDataValue != null)
                    {
                        reportMWQM_Run_SampleModel.MWQM_Run_Sample_Tide_Start = (TideTextEnum)tideDataValue.TideStart;
                        reportMWQM_Run_SampleModel.MWQM_Run_Sample_Tide_End = (TideTextEnum)tideDataValue.TideEnd;
                    }
                }


            }

            return reportMWQM_Run_SampleModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}