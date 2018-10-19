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
    public partial class ReportServiceMunicipality_Contact_Tel
    {
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Municipality_Contact_Tel_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Error);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Error);
                            }
                            break;
                        case "Municipality_Contact_Tel_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Counter);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Counter);
                            }
                            break;
                        case "Municipality_Contact_Tel_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_ID);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_ID);
                            }
                            break;
                        case "Municipality_Contact_Tel_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Type);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Type);
                            }
                            break;
                        case "Municipality_Contact_Tel_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Number);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Number);
                            }
                            break;
                        case "Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Municipality_Contact_Tel_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Last_Update_Contact_Name);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Last_Update_Contact_Name);
                            }
                            break;
                        case "Municipality_Contact_Tel_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderBy(c => c.Municipality_Contact_Tel_Last_Update_Contact_Initial);
                                else
                                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.OrderByDescending(c => c.Municipality_Contact_Tel_Last_Update_Contact_Initial);
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
                        case "Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_YEAR(reportMunicipality_Contact_TelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_MONTH(reportMunicipality_Contact_TelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_DAY(reportMunicipality_Contact_TelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_HOUR(reportMunicipality_Contact_TelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_MINUTE(reportMunicipality_Contact_TelModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Municipality_Contact_Tel_Error":
                            reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Error(reportMunicipality_Contact_TelModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Tel_Number":
                            reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Number(reportMunicipality_Contact_TelModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Tel_Last_Update_Contact_Name":
                            reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Contact_Name(reportMunicipality_Contact_TelModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Tel_Last_Update_Contact_Initial":
                            reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Contact_Initial(reportMunicipality_Contact_TelModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Municipality_Contact_Tel_Counter":
                            reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Counter(reportMunicipality_Contact_TelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Contact_Tel_ID":
                            reportMunicipality_Contact_TelModelQ = ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_ID(reportMunicipality_Contact_TelModelQ, reportTreeNode, dbFilteringNumberField);
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
            #region Filter TelTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TelType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Municipality_Contact_Tel_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TelTypeEnum> TelTypeEqualList = new List<TelTypeEnum>();
                                List<string> TelTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TelTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TelTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TelTypeEnum)i).ToString())
                                        {
                                            TelTypeEqualList.Add((TelTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TelTypeEqualList.Add(TelTypeEnum.Error);
                                }
                                reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => TelTypeEqualList.Contains((TelTypeEnum)c.Municipality_Contact_Tel_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TelTypeEnum
            return reportMunicipality_Contact_TelModelQ;
        }

        // Date Functions
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_TelModelQ;
        }

        // Text Functions
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Error(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Number(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Contact_Name(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Last_Update_Contact_Initial(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => String.Compare(c.Municipality_Contact_Tel_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_TelModelQ;
        }

        // Number Functions
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_Counter(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_TelModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_TelModel> ReportServiceGeneratedMunicipality_Contact_Tel_Municipality_Contact_Tel_ID(IQueryable<ReportMunicipality_Contact_TelModel> reportMunicipality_Contact_TelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_TelModelQ = reportMunicipality_Contact_TelModelQ.Where(c => c.Municipality_Contact_Tel_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_TelModelQ;
        }
    }
}
