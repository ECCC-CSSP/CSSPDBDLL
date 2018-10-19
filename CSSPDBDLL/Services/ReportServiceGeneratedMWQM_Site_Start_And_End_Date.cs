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
    public partial class ReportServiceMWQM_Site_Start_And_End_Date
    {
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Site_Start_And_End_Date_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_Error);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_Error);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_Counter);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_Counter);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_ID);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_ID);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_Start_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_Start_Date);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_Start_Date);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_End_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_End_Date);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_End_Date);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderBy(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial);
                                else
                                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.OrderByDescending(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial);
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
                        case "MWQM_Site_Start_And_End_Date_Start_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_YEAR(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_MONTH(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_DAY(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_HOUR(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_MINUTE(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_End_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_YEAR(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_MONTH(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_DAY(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_HOUR(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_MINUTE(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_YEAR(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_MONTH(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_DAY(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_HOUR(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_MINUTE(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MWQM_Site_Start_And_End_Date_Error":
                            reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Error(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name":
                            reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial":
                            reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MWQM_Site_Start_And_End_Date_Counter":
                            reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Counter(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Start_And_End_Date_ID":
                            reportMWQM_Site_Start_And_End_DateModelQ = ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_ID(reportMWQM_Site_Start_And_End_DateModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }

        // Date Functions
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_YEAR(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_YEAR(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_MONTH(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_MONTH(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_DAY(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_DAY(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_HOUR(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_HOUR(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Start_Date_MINUTE(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Start_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_End_Date_MINUTE(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_End_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_Start_And_End_DateModelQ;
        }

        // Text Functions
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Error(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => String.Compare(c.MWQM_Site_Start_And_End_Date_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => String.Compare(c.MWQM_Site_Start_And_End_Date_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => String.Compare(c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => String.Compare(c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => String.Compare(c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => String.Compare(c.MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_Start_And_End_DateModelQ;
        }

        // Number Functions
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_Counter(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
        public IQueryable<ReportMWQM_Site_Start_And_End_DateModel> ReportServiceGeneratedMWQM_Site_Start_And_End_Date_MWQM_Site_Start_And_End_Date_ID(IQueryable<ReportMWQM_Site_Start_And_End_DateModel> reportMWQM_Site_Start_And_End_DateModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_Start_And_End_DateModelQ = reportMWQM_Site_Start_And_End_DateModelQ.Where(c => c.MWQM_Site_Start_And_End_Date_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_Start_And_End_DateModelQ;
        }
    }
}
