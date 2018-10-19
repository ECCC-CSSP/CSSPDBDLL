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
    public partial class ReportServiceHydrometric_Site_Rating_Curve_Value
    {
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Hydrometric_Site_Rating_Curve_Value_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Error);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Error);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Counter);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Counter);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_ID);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_ID);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Stage_Value_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Stage_Value_m);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Stage_Value_m);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name);
                            }
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderBy(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial);
                                else
                                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.OrderByDescending(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial);
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
                        case "Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_YEAR(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_MONTH(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_DAY(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_HOUR(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_MINUTE(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Hydrometric_Site_Rating_Curve_Value_Error":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Error(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Hydrometric_Site_Rating_Curve_Value_Counter":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Counter(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_ID":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_ID(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Stage_Value_m":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Stage_Value_m(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s":
                            reportHydrometric_Site_Rating_Curve_ValueModelQ = ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s(reportHydrometric_Site_Rating_Curve_ValueModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }

        // Date Functions
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_YEAR(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_MONTH(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_DAY(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_HOUR(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC_MINUTE(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }

        // Text Functions
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Error(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => String.Compare(c.Hydrometric_Site_Rating_Curve_Value_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => String.Compare(c.Hydrometric_Site_Rating_Curve_Value_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => String.Compare(c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => String.Compare(c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => String.Compare(c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => String.Compare(c.Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }

        // Number Functions
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Counter(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_ID(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Stage_Value_m(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Stage_Value_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Stage_Value_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Stage_Value_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
        public IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportServiceGeneratedHydrometric_Site_Rating_Curve_Value_Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s(IQueryable<ReportHydrometric_Site_Rating_Curve_ValueModel> reportHydrometric_Site_Rating_Curve_ValueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_Rating_Curve_ValueModelQ = reportHydrometric_Site_Rating_Curve_ValueModelQ.Where(c => c.Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_Rating_Curve_ValueModelQ;
        }
    }
}
