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
    public partial class ReportServiceSubsector
    {
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Error);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Error);
                            }
                            break;
                        case "Subsector_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Counter);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Counter);
                            }
                            break;
                        case "Subsector_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_ID);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_ID);
                            }
                            break;
                        case "Subsector_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Name_Translation_Status);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Name_Translation_Status);
                            }
                            break;
                        case "Subsector_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Name_Short);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Name_Short);
                            }
                            break;
                        case "Subsector_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Name_Long);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Name_Long);
                            }
                            break;
                        case "Subsector_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Is_Active);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Is_Active);
                            }
                            break;
                        case "Subsector_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Last_Update_Date_And_Time_UTC);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Subsector_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Last_Update_Contact_Name);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Last_Update_Contact_Initial);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Subsector_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Lat);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Lat);
                            }
                            break;
                        case "Subsector_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Lng);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Lng);
                            }
                            break;
                        case "Subsector_Stat_Municipality_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_Municipality_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_Municipality_Count);
                            }
                            break;
                        case "Subsector_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_Lift_Station_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Subsector_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_WWTP_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_WWTP_Count);
                            }
                            break;
                        case "Subsector_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_MWQM_Sample_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "Subsector_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_MWQM_Site_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "Subsector_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_MWQM_Run_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "Subsector_Stat_Pol_Source_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_Pol_Source_Site_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_Pol_Source_Site_Count);
                            }
                            break;
                        case "Subsector_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_Mike_Scenario_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Subsector_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_Box_Model_Scenario_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Subsector_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderBy(c => c.Subsector_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportSubsectorModelQ = reportSubsectorModelQ.OrderByDescending(c => c.Subsector_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Subsector_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_YEAR(reportSubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_MONTH(reportSubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_DAY(reportSubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_HOUR(reportSubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_MINUTE(reportSubsectorModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Error":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Error(reportSubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Name_Short":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Name_Short(reportSubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Name_Long":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Name_Long(reportSubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Last_Update_Contact_Name":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Contact_Name(reportSubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Last_Update_Contact_Initial":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Last_Update_Contact_Initial(reportSubsectorModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Counter":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Counter(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_ID":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_ID(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lat":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Lat(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lng":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Lng(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_Municipality_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_Municipality_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_Lift_Station_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_Lift_Station_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_WWTP_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_WWTP_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_MWQM_Sample_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_MWQM_Sample_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_MWQM_Site_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_MWQM_Site_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_MWQM_Run_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_MWQM_Run_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_Pol_Source_Site_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_Pol_Source_Site_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_Mike_Scenario_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_Mike_Scenario_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_Box_Model_Scenario_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_Box_Model_Scenario_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Stat_Visual_Plumes_Scenario_Count":
                            reportSubsectorModelQ = ReportServiceGeneratedSubsector_Subsector_Stat_Visual_Plumes_Scenario_Count(reportSubsectorModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Is_Active == true);
                            else
                                reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Is_Active == false);
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
                        case "Subsector_Name_Translation_Status":
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
                                reportSubsectorModelQ = reportSubsectorModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Subsector_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportSubsectorModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsectorModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Error(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Name_Short(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Name_Long(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Contact_Name(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Last_Update_Contact_Initial(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => String.Compare(c.Subsector_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Counter(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_ID(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Lat(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Lng(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_Municipality_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Municipality_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Municipality_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Municipality_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_Lift_Station_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_WWTP_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_MWQM_Sample_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_MWQM_Site_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_MWQM_Run_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_Pol_Source_Site_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Pol_Source_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Pol_Source_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Pol_Source_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_Mike_Scenario_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_Box_Model_Scenario_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
        public IQueryable<ReportSubsectorModel> ReportServiceGeneratedSubsector_Subsector_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportSubsectorModel> reportSubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsectorModelQ = reportSubsectorModelQ.Where(c => c.Subsector_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsectorModelQ;
        }
    }
}
