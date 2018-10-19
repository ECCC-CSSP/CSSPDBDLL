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
    public partial class ReportServiceSubsector_Hydrometric_Site_Rating_Curve
    {
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Hydrometric_Site_Rating_Curve_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_Error);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_Error);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_Counter);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_Counter);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_ID);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_ID);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial);
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
                        case "Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_YEAR(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_MONTH(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_DAY(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_HOUR(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_MINUTE(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Hydrometric_Site_Rating_Curve_Error":
                            reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Error(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number":
                            reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name":
                            reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial":
                            reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Hydrometric_Site_Rating_Curve_Counter":
                            reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Counter(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_Rating_Curve_ID":
                            reportSubsector_Hydrometric_Site_Rating_CurveModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_ID(reportSubsector_Hydrometric_Site_Rating_CurveModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Error(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_Counter(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Rating_Curve_Subsector_Hydrometric_Site_Rating_Curve_ID(IQueryable<ReportSubsector_Hydrometric_Site_Rating_CurveModel> reportSubsector_Hydrometric_Site_Rating_CurveModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_Site_Rating_CurveModelQ = reportSubsector_Hydrometric_Site_Rating_CurveModelQ.Where(c => c.Subsector_Hydrometric_Site_Rating_Curve_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_Site_Rating_CurveModelQ;
        }
    }
}
