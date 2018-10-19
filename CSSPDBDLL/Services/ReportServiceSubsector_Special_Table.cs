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
    public partial class ReportServiceSubsector_Special_Table : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; set; }
        public MWQMSiteService _MWQMSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Special_Table(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MWQMSiteService = new MWQMSiteService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Special_TableModel> GetReportSubsector_Special_TableModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = new List<ReportSubsector_Special_TableModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Special_Table";

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (ParentTagItem != "Subsector")
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, ServiceRes.Subsector, ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Special_TableModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = retStr } };

            // Subsector_Special_Table_Last_X_Runs
            ReportTreeNode reportTreeNodeXRuns = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Last_X_Runs").FirstOrDefault();
            if (reportTreeNodeXRuns == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Last_X_Runs" } };

            if (reportTreeNodeXRuns.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Last_X_Runs" } };

            if (reportTreeNodeXRuns.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Last_X_Runs" } };

            int Subsector_Special_Table_Last_X_Runs = (int)reportTreeNodeXRuns.dbFilteringNumberFieldList[0].NumberCondition;

            // Subsector_Special_Table_Type
            ReportTreeNode reportTreeNodeSpecialTableType = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Type").FirstOrDefault();
            if (reportTreeNodeSpecialTableType == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Type" } };

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Type" } };

            SpecialTableTypeEnum Subsector_Special_Table_Type = SpecialTableTypeEnum.Error;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.FCDensitiesTable.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.FCDensitiesTable;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.GeometricMeanTable.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.GeometricMeanTable;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.MedianTable.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.MedianTable;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.P90Table.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.P90Table;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.PercentOver260Table.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.PercentOver260Table;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.PercentOver43Table.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.PercentOver43Table;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.SalinityTable.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.SalinityTable;

            if (reportTreeNodeSpecialTableType.dbFilteringEnumFieldList[0].EnumConditionText == SpecialTableTypeEnum.TemperatureTable.ToString())
                Subsector_Special_Table_Type = SpecialTableTypeEnum.TemperatureTable;

            if (Subsector_Special_Table_Type == SpecialTableTypeEnum.Error)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Type" } };

            // Subsector_Special_Table_MWQM_Site_Is_Active
            ReportTreeNode reportTreeNodeIsActive = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_MWQM_Site_Is_Active").FirstOrDefault();
            bool? Subsector_Special_Table_MWQM_Site_Is_Active = null;
            if (reportTreeNodeIsActive != null)
            {
                if (reportTreeNodeIsActive.dbFilteringTrueFalseFieldList.Count > 0)
                {
                    if (reportTreeNodeIsActive.dbFilteringTrueFalseFieldList[0].ReportCondition == ReportConditionEnum.ReportConditionTrue)
                    {
                        Subsector_Special_Table_MWQM_Site_Is_Active = true;
                    }
                    else
                    {
                        Subsector_Special_Table_MWQM_Site_Is_Active = false;
                    }
                }
            }

            // Subsector_Special_Table_Number_Of_Samples_For_Stat_Max
            ReportTreeNode reportTreeNodeNumberOfSampleStatMax = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Number_Of_Samples_For_Stat_Max").FirstOrDefault();
            if (reportTreeNodeNumberOfSampleStatMax == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Max" } };

            if (reportTreeNodeNumberOfSampleStatMax.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Max" } };

            if (reportTreeNodeNumberOfSampleStatMax.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Max" } };

            int Subsector_Special_Table_Number_Of_Samples_For_Stat_Max = (int)reportTreeNodeNumberOfSampleStatMax.dbFilteringNumberFieldList[0].NumberCondition;

            // Subsector_Special_Table_Number_Of_Samples_For_Stat_Min
            ReportTreeNode reportTreeNodeNumberOfSampleStatMin = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Number_Of_Samples_For_Stat_Min").FirstOrDefault();
            if (reportTreeNodeNumberOfSampleStatMin == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Min" } };

            if (reportTreeNodeNumberOfSampleStatMin.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Min" } };

            if (reportTreeNodeNumberOfSampleStatMin.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Min" } };

            int Subsector_Special_Table_Number_Of_Samples_For_Stat_Min = (int)reportTreeNodeNumberOfSampleStatMin.dbFilteringNumberFieldList[0].NumberCondition;

            // Subsector_Special_Table_Highlight_Above_Min_Number
            ReportTreeNode reportTreeNodeHighlightAboveMinNumber = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Highlight_Above_Min_Number").FirstOrDefault();
            if (reportTreeNodeHighlightAboveMinNumber == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Above_Min_Number" } };

            if (reportTreeNodeHighlightAboveMinNumber.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Above_Min_Number" } };

            if (reportTreeNodeHighlightAboveMinNumber.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Above_Min_Number" } };

            int Subsector_Special_Table_Highlight_Above_Min_Number = (int)reportTreeNodeHighlightAboveMinNumber.dbFilteringNumberFieldList[0].NumberCondition;

            // Subsector_Special_Table_Highlight_Below_Max_Number
            ReportTreeNode reportTreeNodeHighlightBelowMaxNumber = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Highlight_Below_Max_Number").FirstOrDefault();
            if (reportTreeNodeHighlightBelowMaxNumber == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Below_Max_Number" } };

            if (reportTreeNodeHighlightBelowMaxNumber.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Below_Max_Number" } };

            if (reportTreeNodeHighlightBelowMaxNumber.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Below_Max_Number" } };

            int Subsector_Special_Table_Highlight_Below_Max_Number = (int)reportTreeNodeHighlightBelowMaxNumber.dbFilteringNumberFieldList[0].NumberCondition;

            // Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation
            ReportTreeNode reportTreeNodeShowNumberOfDaysOfPrecipitation = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation").FirstOrDefault();
            if (reportTreeNodeShowNumberOfDaysOfPrecipitation == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation" } };

            if (reportTreeNodeShowNumberOfDaysOfPrecipitation.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation" } };

            if (reportTreeNodeShowNumberOfDaysOfPrecipitation.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation" } };

            int Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation = (int)reportTreeNodeShowNumberOfDaysOfPrecipitation.dbFilteringNumberFieldList[0].NumberCondition;

            // Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part
            ReportTreeNode reportTreeNodeMaximumNumberOfSitesPerTablePart = reportTreeNodeList.Where(c => c.Text == "Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part").FirstOrDefault();
            if (reportTreeNodeMaximumNumberOfSitesPerTablePart == null)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part" } };

            if (reportTreeNodeMaximumNumberOfSitesPerTablePart.dbFilteringNumberFieldList.Count == 0)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part" } };

            if (reportTreeNodeMaximumNumberOfSitesPerTablePart.dbFilteringNumberFieldList[0].ReportCondition != ReportConditionEnum.ReportConditionEqual)
                return new List<ReportSubsector_Special_TableModel>() { new ReportSubsector_Special_TableModel() { Subsector_Special_Table_Error = string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part" } };

            int Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part = (int)reportTreeNodeMaximumNumberOfSitesPerTablePart.dbFilteringNumberFieldList[0].NumberCondition;

            var runIDAndDateList =
                (from c in db.TVItems
                 from r in db.MWQMRuns
                 where r.SubsectorTVItemID == c.TVItemID
                 && c.TVItemID == UnderTVItemID
                 orderby r.DateTime_Local descending
                 select new
                 {
                     r.MWQMRunTVItemID,
                     r.DateTime_Local,
                     r.Tide_Start,
                     r.Tide_End,
                     r.RainDay1_mm,
                     r.RainDay2_mm,
                     r.RainDay3_mm,
                     r.RainDay4_mm,
                     r.RainDay5_mm
                 }).Take(Subsector_Special_Table_Last_X_Runs).ToList();

            // got subsector run date list in descending order
            var siteIDAndNameList = (Subsector_Special_Table_MWQM_Site_Is_Active == null ?
               (from s in db.TVItems
                from sl in db.TVItemLanguages
                where s.TVItemID == sl.TVItemID
                && s.ParentID == UnderTVItemID
                && s.TVType == (int)TVTypeEnum.MWQMSite
                && sl.Language == (int)Language
                orderby sl.TVText
                select new
                {
                    s.TVItemID,
                    sl.TVText
                }).ToList() : (Subsector_Special_Table_MWQM_Site_Is_Active == true ?
                    (from s in db.TVItems
                     from sl in db.TVItemLanguages
                     where s.TVItemID == sl.TVItemID
                     && s.IsActive == true
                     && s.ParentID == UnderTVItemID
                     && s.TVType == (int)TVTypeEnum.MWQMSite
                     && sl.Language == (int)Language
                     orderby sl.TVText
                     select new
                     {
                         s.TVItemID,
                         sl.TVText
                     }).ToList() : (from s in db.TVItems
                                    from sl in db.TVItemLanguages
                                    where s.TVItemID == sl.TVItemID
                                    && s.IsActive == false
                                    && s.ParentID == UnderTVItemID
                                    && s.TVType == (int)TVTypeEnum.MWQMSite
                                    && sl.Language == (int)Language
                                    orderby sl.TVText
                                    select new
                                    {
                                        s.TVItemID,
                                        sl.TVText
                                    }).ToList()));

            ReportSubsector_Special_TableModel reportSubsector_Special_TableModel = new ReportSubsector_Special_TableModel();
            reportSubsector_Special_TableModel.Subsector_Special_Table_Last_X_Runs = Subsector_Special_Table_Last_X_Runs;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Type = Subsector_Special_Table_Type;
            reportSubsector_Special_TableModel.Subsector_Special_Table_MWQM_Site_Is_Active = Subsector_Special_Table_MWQM_Site_Is_Active;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Number_Of_Samples_For_Stat_Max = Subsector_Special_Table_Number_Of_Samples_For_Stat_Max;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Number_Of_Samples_For_Stat_Min = Subsector_Special_Table_Number_Of_Samples_For_Stat_Min;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Highlight_Above_Min_Number = Subsector_Special_Table_Highlight_Above_Min_Number;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Highlight_Below_Max_Number = Subsector_Special_Table_Highlight_Below_Max_Number;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation = Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation;
            reportSubsector_Special_TableModel.Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part = Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part;

            bool DateListDone = false;
            foreach (var site in siteIDAndNameList)
            {
                reportSubsector_Special_TableModel.Subsector_Special_Table_MWQM_Site_Name_List = reportSubsector_Special_TableModel.Subsector_Special_Table_MWQM_Site_Name_List + site.TVText + "|";

                List<MWQMSiteSampleFCModel> mwqmSiteSampleStatModelList = _MWQMSiteService.CalculateMWQMSiteStatMovingAverage(site.TVItemID, (int)Subsector_Special_Table_Number_Of_Samples_For_Stat_Max, (int)Subsector_Special_Table_Number_Of_Samples_For_Stat_Min).OrderByDescending(c => c.SampleDate).ToList();
                TVLocation tvLoc = new TVLocation();
                if (mwqmSiteSampleStatModelList.Count == 0)
                {
                    reportSubsector_Special_TableModel.Subsector_Special_Table_Stat_Letter_List = reportSubsector_Special_TableModel.Subsector_Special_Table_Stat_Letter_List + ((int)TVTypeEnum.NoData).ToString() + "_0|";
                }
                else
                {
                    if (mwqmSiteSampleStatModelList[0].P90 == null || mwqmSiteSampleStatModelList[0].GeoMean == null || mwqmSiteSampleStatModelList[0].Median == null || mwqmSiteSampleStatModelList[0].PercOver43 == null || mwqmSiteSampleStatModelList[0].PercOver260 == null)
                    {
                        reportSubsector_Special_TableModel.Subsector_Special_Table_Stat_Letter_List = reportSubsector_Special_TableModel.Subsector_Special_Table_Stat_Letter_List + ((int)TVTypeEnum.LessThan10).ToString() + "_" + mwqmSiteSampleStatModelList[0].SampCount + "|";
                    }
                    else
                    {
                        _MWQMSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvLoc, (double)mwqmSiteSampleStatModelList[0].P90, (double)mwqmSiteSampleStatModelList[0].GeoMean, (double)mwqmSiteSampleStatModelList[0].Median, (double)mwqmSiteSampleStatModelList[0].PercOver43, (double)mwqmSiteSampleStatModelList[0].PercOver260);
                        reportSubsector_Special_TableModel.Subsector_Special_Table_Stat_Letter_List = reportSubsector_Special_TableModel.Subsector_Special_Table_Stat_Letter_List + "" + ((int)tvLoc.SubTVType).ToString() + "_" + tvLoc.TVText.Substring(0, 1) + "|";
                    }
                }
                reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List = reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List + "Start|" + site.TVText + "|";
                List<MWQMSample> siteValueList = (from c in db.MWQMSamples
                                                  where c.MWQMSiteTVItemID == site.TVItemID
                                                  select c).ToList();

                //foreach (int YearOfRun in runIDAndDateList.Select(c => c.DateTime_Local.Year).Distinct().OrderByDescending(c => c).ToList())
                //{
                foreach (var runIDAndDate in runIDAndDateList.OrderByDescending(c => c.DateTime_Local))
                {
                    if (!DateListDone)
                    {
                        reportSubsector_Special_TableModel.Subsector_Special_Table_MWQM_Run_Date_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_MWQM_Run_Date_List +
                            runIDAndDate.DateTime_Local.Year.ToString()
                            + (runIDAndDate.DateTime_Local.Month < 10 ? "0" + runIDAndDate.DateTime_Local.Month.ToString() : runIDAndDate.DateTime_Local.Month.ToString())
                            + (runIDAndDate.DateTime_Local.Day < 10 ? "0" + runIDAndDate.DateTime_Local.Day.ToString() : runIDAndDate.DateTime_Local.Day.ToString()) + "|";

                        reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_1_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_1_Value_List +
                            (runIDAndDate.RainDay1_mm != null ? ((double)runIDAndDate.RainDay1_mm).ToString("F0") : "-1") + "|";

                        reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_2_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_2_Value_List +
                            (runIDAndDate.RainDay2_mm != null ? ((double)runIDAndDate.RainDay2_mm).ToString("F0") : "-1") + "|";

                        reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_3_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_3_Value_List +
                            (runIDAndDate.RainDay3_mm != null ? ((double)runIDAndDate.RainDay3_mm).ToString("F0") : "-1") + "|";

                        reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_4_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_4_Value_List +
                            (runIDAndDate.RainDay4_mm != null ? ((double)runIDAndDate.RainDay4_mm).ToString("F0") : "-1") + "|";

                        reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_5_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Rain_Day_5_Value_List +
                            (runIDAndDate.RainDay5_mm != null ? ((double)runIDAndDate.RainDay5_mm).ToString("F0") : "-1") + "|";

                        reportSubsector_Special_TableModel.Subsector_Special_Table_Tide_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Tide_Value_List +
                            (runIDAndDate.Tide_Start != null ? runIDAndDate.Tide_Start.ToString() : "EE") + "-" + (runIDAndDate.Tide_End != null ? runIDAndDate.Tide_End.ToString() : "EE") + "|";

                    }

                    var sampleRunSiteAndValueList =
                        (from sp in siteValueList
                         where runIDAndDate.MWQMRunTVItemID == sp.MWQMRunTVItemID
                         && sp.MWQMSiteTVItemID == sp.MWQMSiteTVItemID
                         && sp.SampleTypesText.Contains(((int)SampleTypeEnum.Routine).ToString() + ",")
                         orderby sp.SampleDateTime_Local
                         select new
                         {
                             sp.FecCol_MPN_100ml,
                             sp.Salinity_PPT,
                             sp.WaterTemp_C,
                         }).FirstOrDefault();

                    if (sampleRunSiteAndValueList != null)
                    {
                        switch (Subsector_Special_Table_Type)
                        {
                            case SpecialTableTypeEnum.FCDensitiesTable:
                                {
                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                        reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                        (sampleRunSiteAndValueList.FecCol_MPN_100ml != null ? ((double)sampleRunSiteAndValueList.FecCol_MPN_100ml).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.SalinityTable:
                                {
                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                        reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                        (sampleRunSiteAndValueList.Salinity_PPT != null ? ((double)sampleRunSiteAndValueList.Salinity_PPT).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.TemperatureTable:
                                {
                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                        reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                        (sampleRunSiteAndValueList.WaterTemp_C != null ? ((double)sampleRunSiteAndValueList.WaterTemp_C).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.GeometricMeanTable:
                                {
                                    float? tempValue = mwqmSiteSampleStatModelList.Where(c => c.SampleDate.Year == runIDAndDate.DateTime_Local.Year
                                    && c.SampleDate.Month == runIDAndDate.DateTime_Local.Month
                                    && c.SampleDate.Day == runIDAndDate.DateTime_Local.Day).Select(c => c.GeoMean).FirstOrDefault();

                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                       reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                       (tempValue != null ? ((double)tempValue).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.MedianTable:
                                {
                                    float? tempValue = mwqmSiteSampleStatModelList.Where(c => c.SampleDate.Year == runIDAndDate.DateTime_Local.Year
                                    && c.SampleDate.Month == runIDAndDate.DateTime_Local.Month
                                    && c.SampleDate.Day == runIDAndDate.DateTime_Local.Day).Select(c => c.Median).FirstOrDefault();

                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                       reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                       (tempValue != null ? ((double)tempValue).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.P90Table:
                                {
                                    float? tempValue = mwqmSiteSampleStatModelList.Where(c => c.SampleDate.Year == runIDAndDate.DateTime_Local.Year
                                    && c.SampleDate.Month == runIDAndDate.DateTime_Local.Month
                                    && c.SampleDate.Day == runIDAndDate.DateTime_Local.Day).Select(c => c.P90).FirstOrDefault();

                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                       reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                       (tempValue != null ? ((double)tempValue).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.PercentOver43Table:
                                {
                                    float? tempValue = mwqmSiteSampleStatModelList.Where(c => c.SampleDate.Year == runIDAndDate.DateTime_Local.Year
                                    && c.SampleDate.Month == runIDAndDate.DateTime_Local.Month
                                    && c.SampleDate.Day == runIDAndDate.DateTime_Local.Day).Select(c => c.PercOver43).FirstOrDefault();

                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                       reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                       (tempValue != null ? ((double)tempValue).ToString("F0") : "-1") + "|";
                                }
                                break;
                            case SpecialTableTypeEnum.PercentOver260Table:
                                {
                                    float? tempValue = mwqmSiteSampleStatModelList.Where(c => c.SampleDate.Year == runIDAndDate.DateTime_Local.Year
                                    && c.SampleDate.Month == runIDAndDate.DateTime_Local.Month
                                    && c.SampleDate.Day == runIDAndDate.DateTime_Local.Day).Select(c => c.PercOver260).FirstOrDefault();

                                    reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                                       reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List +
                                       (tempValue != null ? ((double)tempValue).ToString("F0") : "-1") + "|";
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List =
                            reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List + "|";
                    }

                }
                //}
                DateListDone = true;

                reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List = reportSubsector_Special_TableModel.Subsector_Special_Table_Parameter_Value_List + "End|";
            }

            reportSubsector_Special_TableModelList.Add(reportSubsector_Special_TableModel);

            return reportSubsector_Special_TableModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}