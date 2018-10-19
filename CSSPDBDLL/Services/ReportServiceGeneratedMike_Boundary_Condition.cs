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
    public partial class ReportServiceMike_Boundary_Condition
    {
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Boundary_Condition_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Error);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Error);
                            }
                            break;
                        case "Mike_Boundary_Condition_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Counter);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Counter);
                            }
                            break;
                        case "Mike_Boundary_Condition_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_ID);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_ID);
                            }
                            break;
                        case "Mike_Boundary_Condition_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Name);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Name);
                            }
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code);
                            }
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name);
                            }
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m);
                            }
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Format":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format);
                            }
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity);
                            }
                            break;
                        case "Mike_Boundary_Condition_Web_Tide_Data_Set":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Web_Tide_Data_Set);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Web_Tide_Data_Set);
                            }
                            break;
                        case "Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes);
                            }
                            break;
                        case "Mike_Boundary_Condition_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC);
                            }
                            break;
                        case "Mike_Boundary_Condition_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Last_Update_Contact_Name);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Last_Update_Contact_Name);
                            }
                            break;
                        case "Mike_Boundary_Condition_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Last_Update_Contact_Initial);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Mike_Boundary_Condition_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Lat);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Lat);
                            }
                            break;
                        case "Mike_Boundary_Condition_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderBy(c => c.Mike_Boundary_Condition_Lng);
                                else
                                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.OrderByDescending(c => c.Mike_Boundary_Condition_Lng);
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
                        case "Mike_Boundary_Condition_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_YEAR(reportMike_Boundary_ConditionModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_MONTH(reportMike_Boundary_ConditionModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_DAY(reportMike_Boundary_ConditionModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_HOUR(reportMike_Boundary_ConditionModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_MINUTE(reportMike_Boundary_ConditionModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Mike_Boundary_Condition_Error":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Error(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Name":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Name(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Code":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Code(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Name":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Name(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Format":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Format(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Web_Tide_Data_Set":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Web_Tide_Data_Set(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Last_Update_Contact_Name":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Contact_Name(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Boundary_Condition_Last_Update_Contact_Initial":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Contact_Initial(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Mike_Boundary_Condition_Counter":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Counter(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Boundary_Condition_ID":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_ID(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Boundary_Condition_Lat":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Lat(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Boundary_Condition_Lng":
                            reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Lng(reportMike_Boundary_ConditionModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportMike_Boundary_ConditionModelQ;
        }

        // Date Functions
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_YEAR(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_MONTH(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_DAY(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_HOUR(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Date_UTC_MINUTE(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Boundary_ConditionModelQ;
        }

        // Text Functions
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Error(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Name(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Code(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Name(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Format(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Format.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Mike_Boundary_Condition_Level_Or_Velocity.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Web_Tide_Data_Set(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Web_Tide_Data_Set.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Web_Tide_Data_Set.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Web_Tide_Data_Set.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Web_Tide_Data_Set.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Web_Tide_Data_Set.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Web_Tide_Data_Set.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Contact_Name(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Last_Update_Contact_Initial(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => String.Compare(c.Mike_Boundary_Condition_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }

        // Number Functions
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Counter(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_ID(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Mike_Boundary_Condition_Length_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Number_Of_Web_Tide_Nodes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Lat(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
        public IQueryable<ReportMike_Boundary_ConditionModel> ReportServiceGeneratedMike_Boundary_Condition_Mike_Boundary_Condition_Lng(IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Boundary_ConditionModelQ = reportMike_Boundary_ConditionModelQ.Where(c => c.Mike_Boundary_Condition_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Boundary_ConditionModelQ;
        }
    }
}
