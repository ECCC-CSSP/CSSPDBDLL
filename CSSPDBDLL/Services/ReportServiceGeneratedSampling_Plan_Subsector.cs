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
    public partial class ReportServiceSampling_Plan_Subsector
    {
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Subsector_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Error);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Error);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Counter);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Counter);
                            }
                            break;
                        case "Sampling_Plan_Subsector_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_ID);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_ID);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Name_Short);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Name_Short);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Name_Long);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Name_Long);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Name);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Name);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Initial);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Lat);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Lat);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Lng);
                                else
                                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Lng);
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
                        case "Sampling_Plan_Subsector_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_YEAR(reportSampling_Plan_SubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_MONTH(reportSampling_Plan_SubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_DAY(reportSampling_Plan_SubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_HOUR(reportSampling_Plan_SubsectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_MINUTE(reportSampling_Plan_SubsectorModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Sampling_Plan_Subsector_Error":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Error(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Name_Short":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Name_Short(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Name_Long":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Name_Long(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Last_Update_Contact_Name":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Contact_Name(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Last_Update_Contact_Initial":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Contact_Initial(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Sampling_Plan_Subsector_Counter":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Counter(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Subsector_ID":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_ID(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Subsector_Lat":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Lat(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Subsector_Lng":
                            reportSampling_Plan_SubsectorModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Lng(reportSampling_Plan_SubsectorModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportSampling_Plan_SubsectorModelQ;
        }

        // Date Functions
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_YEAR(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_MONTH(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_DAY(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_HOUR(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_SubsectorModelQ;
        }

        // Text Functions
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Error(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Name_Short(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Name_Long(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Contact_Name(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Last_Update_Contact_Initial(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }

        // Number Functions
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Counter(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_ID(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Lat(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
        public IQueryable<ReportSampling_Plan_SubsectorModel> ReportServiceGeneratedSampling_Plan_Subsector_Sampling_Plan_Subsector_Lng(IQueryable<ReportSampling_Plan_SubsectorModel> reportSampling_Plan_SubsectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_SubsectorModelQ = reportSampling_Plan_SubsectorModelQ.Where(c => c.Sampling_Plan_Subsector_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_SubsectorModelQ;
        }
    }
}
