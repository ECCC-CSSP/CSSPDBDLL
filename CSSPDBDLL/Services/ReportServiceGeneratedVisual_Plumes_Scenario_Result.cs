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
    public partial class ReportServiceVisual_Plumes_Scenario_Result
    {
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Visual_Plumes_Scenario_Result_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Error);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Error);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Counter);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Counter);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_ID);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_ID);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Ordinal":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Ordinal);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Ordinal);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Concentration_MPN_100ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Concentration_MPN_100ml);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Concentration_MPN_100ml);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Dilution":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Dilution);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Dilution);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Far_Field_Width_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Far_Field_Width_m);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Far_Field_Width_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Dispersion_Distance_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Dispersion_Distance_m);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Dispersion_Distance_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Travel_Time_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Travel_Time_hour);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Travel_Time_hour);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial);
                                else
                                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial);
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
                        case "Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_YEAR(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_MONTH(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_DAY(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_HOUR(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_MINUTE(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Visual_Plumes_Scenario_Result_Error":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Error(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Last_Update_Contact_Name":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Contact_Name(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Visual_Plumes_Scenario_Result_Counter":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Counter(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_ID":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_ID(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Ordinal":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Ordinal(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Concentration_MPN_100ml":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Concentration_MPN_100ml(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Dilution":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Dilution(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Far_Field_Width_m":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Far_Field_Width_m(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Dispersion_Distance_m":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Dispersion_Distance_m(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Result_Travel_Time_hour":
                            reportVisual_Plumes_Scenario_ResultModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Travel_Time_hour(reportVisual_Plumes_Scenario_ResultModelQ, reportTreeNode, dbFilteringNumberField);
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
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportVisual_Plumes_Scenario_ResultModelQ;
        }

        // Date Functions
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_ResultModelQ;
        }

        // Text Functions
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Error(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Result_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Result_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Contact_Name(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }

        // Number Functions
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Counter(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_ID(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Ordinal(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Ordinal > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Ordinal < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Ordinal == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Concentration_MPN_100ml(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Concentration_MPN_100ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Concentration_MPN_100ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Concentration_MPN_100ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Dilution(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Dilution > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Dilution < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Dilution == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Far_Field_Width_m(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Far_Field_Width_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Far_Field_Width_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Far_Field_Width_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Dispersion_Distance_m(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Dispersion_Distance_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Dispersion_Distance_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Dispersion_Distance_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_ResultModel> ReportServiceGeneratedVisual_Plumes_Scenario_Result_Visual_Plumes_Scenario_Result_Travel_Time_hour(IQueryable<ReportVisual_Plumes_Scenario_ResultModel> reportVisual_Plumes_Scenario_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Travel_Time_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Travel_Time_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_ResultModelQ = reportVisual_Plumes_Scenario_ResultModelQ.Where(c => c.Visual_Plumes_Scenario_Result_Travel_Time_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_ResultModelQ;
        }
    }
}
