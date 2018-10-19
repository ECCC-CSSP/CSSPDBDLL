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

namespace CSSPDBDLL.Services
{
    public partial class ReportServiceArea
    {
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea(IQueryable<ReportAreaModel> reportAreaModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Area_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Error);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Error);
                            }
                            break;
                        case "Area_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Counter);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Counter);
                            }
                            break;
                        case "Area_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_ID);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_ID);
                            }
                            break;
                        case "Area_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Name_Translation_Status);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Name_Translation_Status);
                            }
                            break;
                        case "Area_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Name_Short);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Name_Short);
                            }
                            break;
                        case "Area_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Name_Long);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Name_Long);
                            }
                            break;
                        case "Area_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Is_Active);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Is_Active);
                            }
                            break;
                        case "Area_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Last_Update_Date_And_Time_UTC);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Area_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Last_Update_Contact_Name);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Last_Update_Contact_Name);
                            }
                            break;
                        case "Area_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Last_Update_Contact_Initial);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Area_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Lat);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Lat);
                            }
                            break;
                        case "Area_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Lng);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Lng);
                            }
                            break;
                        case "Area_Stat_Sector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Sector_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Sector_Count);
                            }
                            break;
                        case "Area_Stat_Subsector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Subsector_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Subsector_Count);
                            }
                            break;
                        case "Area_Stat_Municipality_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Municipality_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Municipality_Count);
                            }
                            break;
                        case "Area_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Lift_Station_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Area_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_WWTP_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_WWTP_Count);
                            }
                            break;
                        case "Area_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_MWQM_Sample_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "Area_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_MWQM_Site_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "Area_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_MWQM_Run_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "Area_Stat_Pol_Source_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Pol_Source_Site_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Pol_Source_Site_Count);
                            }
                            break;
                        case "Area_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Mike_Scenario_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Area_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Box_Model_Scenario_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Area_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportAreaModelQ = reportAreaModelQ.OrderBy(c => c.Area_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportAreaModelQ = reportAreaModelQ.OrderByDescending(c => c.Area_Stat_Visual_Plumes_Scenario_Count);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Sorting
            #region Filter Date
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringDateFieldList.Count > 0))
            {
                foreach (ReportConditionDateField reportConditionDateField in reportTreeNode.dbFilteringDateFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Area_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_YEAR(reportAreaModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_MONTH(reportAreaModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_DAY(reportAreaModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_HOUR(reportAreaModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_MINUTE(reportAreaModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter Date
            #region Filter Text
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringTextFieldList.Count > 0))
            {
                foreach (ReportConditionTextField dbFilteringTextField in reportTreeNode.dbFilteringTextFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Area_Error":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Error(reportAreaModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Area_Name_Short":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Name_Short(reportAreaModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Area_Name_Long":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Name_Long(reportAreaModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Area_Last_Update_Contact_Name":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Contact_Name(reportAreaModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Area_Last_Update_Contact_Initial":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Last_Update_Contact_Initial(reportAreaModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter Text
            #region Filter Number
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringNumberFieldList.Count > 0))
            {
                foreach (ReportConditionNumberField dbFilteringNumberField in reportTreeNode.dbFilteringNumberFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Area_Counter":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Counter(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_ID":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_ID(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Lat":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Lat(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Lng":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Lng(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Sector_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Sector_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Subsector_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Subsector_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Municipality_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Municipality_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Lift_Station_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Lift_Station_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_WWTP_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_WWTP_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_MWQM_Sample_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_MWQM_Sample_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_MWQM_Site_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_MWQM_Site_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_MWQM_Run_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_MWQM_Run_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Pol_Source_Site_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Pol_Source_Site_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Mike_Scenario_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Mike_Scenario_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Box_Model_Scenario_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Box_Model_Scenario_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Area_Stat_Visual_Plumes_Scenario_Count":
                            reportAreaModelQ = ReportServiceGeneratedArea_Area_Stat_Visual_Plumes_Scenario_Count(reportAreaModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter Number
            #region Filter TrueFalse
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringTrueFalseFieldList.Count > 0))
            {
                foreach (ReportConditionTrueFalseField reportTrueFalseField in reportTreeNode.dbFilteringTrueFalseFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Area_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Is_Active == true);
                            else
                                reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Is_Active == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            #region Filter TranslationStatusEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TranslationStatus))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Area_Name_Translation_Status":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TranslationStatusEnum> TranslationStatusEqualList = new List<TranslationStatusEnum>();
                                List<string> TranslationStatusTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TranslationStatusTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TranslationStatusEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TranslationStatusEnum)i).ToString())
                                        {
                                            TranslationStatusEqualList.Add((TranslationStatusEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TranslationStatusEqualList.Add(TranslationStatusEnum.Error);
                                }
                                reportAreaModelQ = reportAreaModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Area_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportAreaModelQ;
        }

        // Date Functions
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Area_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            else if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportAreaModelQ;
        }

        // Text Functions
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Error(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Name_Short(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Name_Long(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Contact_Name(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Last_Update_Contact_Initial(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => String.Compare(c.Area_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }

        // Number Functions
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Counter(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_ID(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Lat(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Lng(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Sector_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Sector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Sector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Sector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Subsector_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Subsector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Subsector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Subsector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Municipality_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Municipality_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Municipality_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Municipality_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Lift_Station_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_WWTP_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_MWQM_Sample_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_MWQM_Site_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_MWQM_Run_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Pol_Source_Site_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Pol_Source_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Pol_Source_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Pol_Source_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Mike_Scenario_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Box_Model_Scenario_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
        public IQueryable<ReportAreaModel> ReportServiceGeneratedArea_Area_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportAreaModel> reportAreaModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportAreaModelQ = reportAreaModelQ.Where(c => c.Area_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportAreaModelQ;
        }
    }
}
