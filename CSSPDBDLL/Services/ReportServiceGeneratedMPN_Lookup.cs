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
    public partial class ReportServiceMPN_Lookup
    {
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MPN_Lookup_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Error);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Error);
                            }
                            break;
                        case "MPN_Lookup_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Counter);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Counter);
                            }
                            break;
                        case "MPN_Lookup_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_ID);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_ID);
                            }
                            break;
                        case "MPN_Lookup_Tubes_10":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Tubes_10);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Tubes_10);
                            }
                            break;
                        case "MPN_Lookup_Tubes_1_0":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Tubes_1_0);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Tubes_1_0);
                            }
                            break;
                        case "MPN_Lookup_Tubes_0_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Tubes_0_1);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Tubes_0_1);
                            }
                            break;
                        case "MPN_Lookup_MPN_100_ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_MPN_100_ml);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_MPN_100_ml);
                            }
                            break;
                        case "MPN_Lookup_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "MPN_Lookup_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Last_Update_Contact_Name);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Last_Update_Contact_Name);
                            }
                            break;
                        case "MPN_Lookup_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderBy(c => c.MPN_Lookup_Last_Update_Contact_Initial);
                                else
                                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.OrderByDescending(c => c.MPN_Lookup_Last_Update_Contact_Initial);
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
                        case "MPN_Lookup_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_YEAR(reportMPN_LookupModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_MONTH(reportMPN_LookupModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_DAY(reportMPN_LookupModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_HOUR(reportMPN_LookupModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_MINUTE(reportMPN_LookupModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MPN_Lookup_Error":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Error(reportMPN_LookupModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MPN_Lookup_Last_Update_Contact_Name":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Contact_Name(reportMPN_LookupModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MPN_Lookup_Last_Update_Contact_Initial":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Contact_Initial(reportMPN_LookupModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MPN_Lookup_Counter":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Counter(reportMPN_LookupModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MPN_Lookup_ID":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_ID(reportMPN_LookupModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MPN_Lookup_Tubes_10":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Tubes_10(reportMPN_LookupModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MPN_Lookup_Tubes_1_0":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Tubes_1_0(reportMPN_LookupModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MPN_Lookup_Tubes_0_1":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Tubes_0_1(reportMPN_LookupModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MPN_Lookup_MPN_100_ml":
                            reportMPN_LookupModelQ = ReportServiceGeneratedMPN_Lookup_MPN_Lookup_MPN_100_ml(reportMPN_LookupModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportMPN_LookupModelQ;
        }

        // Date Functions
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMPN_LookupModelQ;
        }

        // Text Functions
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Error(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => String.Compare(c.MPN_Lookup_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => String.Compare(c.MPN_Lookup_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Contact_Name(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => String.Compare(c.MPN_Lookup_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => String.Compare(c.MPN_Lookup_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Last_Update_Contact_Initial(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => String.Compare(c.MPN_Lookup_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => String.Compare(c.MPN_Lookup_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }

        // Number Functions
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Counter(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_ID(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Tubes_10(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_10 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_10 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_10 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Tubes_1_0(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_1_0 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_1_0 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_1_0 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_Tubes_0_1(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_0_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_0_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_Tubes_0_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
        public IQueryable<ReportMPN_LookupModel> ReportServiceGeneratedMPN_Lookup_MPN_Lookup_MPN_100_ml(IQueryable<ReportMPN_LookupModel> reportMPN_LookupModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_MPN_100_ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_MPN_100_ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMPN_LookupModelQ = reportMPN_LookupModelQ.Where(c => c.MPN_Lookup_MPN_100_ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMPN_LookupModelQ;
        }
    }
}
