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
    public partial class ReportServiceMike_Source_Start_End
    {
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Source_Start_End_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Error);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Error);
                            }
                            break;
                        case "Mike_Source_Start_End_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Counter);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Counter);
                            }
                            break;
                        case "Mike_Source_Start_End_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_ID);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_ID);
                            }
                            break;
                        case "Mike_Source_Start_End_Start_Date_And_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local);
                            }
                            break;
                        case "Mike_Source_Start_End_End_Date_And_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_End_Date_And_Time_Local);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_End_Date_And_Time_Local);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Flow_Start_m3_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Flow_Start_m3_day);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Flow_Start_m3_day);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Flow_End_m3_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Flow_End_m3_day);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Flow_End_m3_day);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Pollution_End_MPN_100ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Pollution_End_MPN_100ml);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Pollution_End_MPN_100ml);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Temperature_Start_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Temperature_Start_C);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Temperature_Start_C);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Temperature_End_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Temperature_End_C);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Temperature_End_C);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Salinity_Start_PSU":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Salinity_Start_PSU);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Salinity_Start_PSU);
                            }
                            break;
                        case "Mike_Source_Start_End_Source_Salinity_End_PSU":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Source_Salinity_End_PSU);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Source_Salinity_End_PSU);
                            }
                            break;
                        case "Mike_Source_Start_End_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Mike_Source_Start_End_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Last_Update_Contact_Name);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Last_Update_Contact_Name);
                            }
                            break;
                        case "Mike_Source_Start_End_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderBy(c => c.Mike_Source_Start_End_Last_Update_Contact_Initial);
                                else
                                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.OrderByDescending(c => c.Mike_Source_Start_End_Last_Update_Contact_Initial);
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
                        case "Mike_Source_Start_End_Start_Date_And_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_YEAR(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_MONTH(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_DAY(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_HOUR(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_MINUTE(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Mike_Source_Start_End_End_Date_And_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_YEAR(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_MONTH(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_DAY(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_HOUR(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_MINUTE(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Mike_Source_Start_End_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_YEAR(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_MONTH(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_DAY(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_HOUR(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_MINUTE(reportMike_Source_Start_EndModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Mike_Source_Start_End_Error":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Error(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Source_Start_End_Last_Update_Contact_Name":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Contact_Name(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Source_Start_End_Last_Update_Contact_Initial":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Contact_Initial(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Mike_Source_Start_End_Counter":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Counter(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_ID":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_ID(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Flow_Start_m3_day":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Flow_Start_m3_day(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Flow_End_m3_day":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Flow_End_m3_day(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Pollution_End_MPN_100ml":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Pollution_End_MPN_100ml(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Temperature_Start_C":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Temperature_Start_C(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Temperature_End_C":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Temperature_End_C(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Salinity_Start_PSU":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Salinity_Start_PSU(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Source_Start_End_Source_Salinity_End_PSU":
                            reportMike_Source_Start_EndModelQ = ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Salinity_End_PSU(reportMike_Source_Start_EndModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportMike_Source_Start_EndModelQ;
        }

        // Date Functions
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_YEAR(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_YEAR(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_MONTH(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_MONTH(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_DAY(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_DAY(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_HOUR(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_HOUR(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Start_Date_And_Time_Local_MINUTE(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Start_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_End_Date_And_Time_Local_MINUTE(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_End_Date_And_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Source_Start_EndModelQ;
        }

        // Text Functions
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Error(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => String.Compare(c.Mike_Source_Start_End_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => String.Compare(c.Mike_Source_Start_End_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Contact_Name(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => String.Compare(c.Mike_Source_Start_End_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => String.Compare(c.Mike_Source_Start_End_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Last_Update_Contact_Initial(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => String.Compare(c.Mike_Source_Start_End_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => String.Compare(c.Mike_Source_Start_End_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }

        // Number Functions
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Counter(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_ID(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Flow_Start_m3_day(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Flow_Start_m3_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Flow_Start_m3_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Flow_Start_m3_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Flow_End_m3_day(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Flow_End_m3_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Flow_End_m3_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Flow_End_m3_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Pollution_Start_MPN_100ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Pollution_End_MPN_100ml(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Pollution_End_MPN_100ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Pollution_End_MPN_100ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Pollution_End_MPN_100ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Temperature_Start_C(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Temperature_Start_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Temperature_Start_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Temperature_Start_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Temperature_End_C(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Temperature_End_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Temperature_End_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Temperature_End_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Salinity_Start_PSU(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Salinity_Start_PSU > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Salinity_Start_PSU < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Salinity_Start_PSU == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
        public IQueryable<ReportMike_Source_Start_EndModel> ReportServiceGeneratedMike_Source_Start_End_Mike_Source_Start_End_Source_Salinity_End_PSU(IQueryable<ReportMike_Source_Start_EndModel> reportMike_Source_Start_EndModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Salinity_End_PSU > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Salinity_End_PSU < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Source_Start_EndModelQ = reportMike_Source_Start_EndModelQ.Where(c => c.Mike_Source_Start_End_Source_Salinity_End_PSU == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Source_Start_EndModelQ;
        }
    }
}
