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
    public partial class ReportServiceInfrastructure_Address
    {
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Address_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Error);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Error);
                            }
                            break;
                        case "Infrastructure_Address_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Counter);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Counter);
                            }
                            break;
                        case "Infrastructure_Address_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_ID);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_ID);
                            }
                            break;
                        case "Infrastructure_Address_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Type);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Type);
                            }
                            break;
                        case "Infrastructure_Address_Country":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Country);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Country);
                            }
                            break;
                        case "Infrastructure_Address_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Province);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Province);
                            }
                            break;
                        case "Infrastructure_Address_Municipality":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Municipality);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Municipality);
                            }
                            break;
                        case "Infrastructure_Address_Street_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Street_Name);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Street_Name);
                            }
                            break;
                        case "Infrastructure_Address_Street_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Street_Number);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Street_Number);
                            }
                            break;
                        case "Infrastructure_Address_Street_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Street_Type);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Street_Type);
                            }
                            break;
                        case "Infrastructure_Address_Postal_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Postal_Code);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Postal_Code);
                            }
                            break;
                        case "Infrastructure_Address_Google_Address_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Google_Address_Text);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Google_Address_Text);
                            }
                            break;
                        case "Infrastructure_Address_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Infrastructure_Address_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Last_Update_Contact_Name);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Last_Update_Contact_Name);
                            }
                            break;
                        case "Infrastructure_Address_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderBy(c => c.Infrastructure_Address_Last_Update_Contact_Initial);
                                else
                                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.OrderByDescending(c => c.Infrastructure_Address_Last_Update_Contact_Initial);
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
                        case "Infrastructure_Address_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_YEAR(reportInfrastructure_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_MONTH(reportInfrastructure_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_DAY(reportInfrastructure_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_HOUR(reportInfrastructure_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_MINUTE(reportInfrastructure_AddressModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Infrastructure_Address_Error":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Error(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Country":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Country(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Province":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Province(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Municipality":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Municipality(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Street_Name":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Street_Name(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Street_Number":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Street_Number(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Postal_Code":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Postal_Code(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Google_Address_Text":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Google_Address_Text(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Last_Update_Contact_Name":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Contact_Name(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Address_Last_Update_Contact_Initial":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Contact_Initial(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Infrastructure_Address_Counter":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Counter(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Address_ID":
                            reportInfrastructure_AddressModelQ = ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_ID(reportInfrastructure_AddressModelQ, reportTreeNode, dbFilteringNumberField);
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
            #region Filter AddressTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.AddressType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Address_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<AddressTypeEnum> AddressTypeEqualList = new List<AddressTypeEnum>();
                                List<string> AddressTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in AddressTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(AddressTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((AddressTypeEnum)i).ToString())
                                        {
                                            AddressTypeEqualList.Add((AddressTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        AddressTypeEqualList.Add(AddressTypeEnum.Error);
                                }
                                reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => AddressTypeEqualList.Contains((AddressTypeEnum)c.Infrastructure_Address_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter AddressTypeEnum
            #region Filter StreetTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.StreetType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Address_Street_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<StreetTypeEnum> StreetTypeEqualList = new List<StreetTypeEnum>();
                                List<string> StreetTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in StreetTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(StreetTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((StreetTypeEnum)i).ToString())
                                        {
                                            StreetTypeEqualList.Add((StreetTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        StreetTypeEqualList.Add(StreetTypeEnum.Error);
                                }
                                reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => StreetTypeEqualList.Contains((StreetTypeEnum)c.Infrastructure_Address_Street_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter StreetTypeEnum
            return reportInfrastructure_AddressModelQ;
        }

        // Date Functions
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructure_AddressModelQ;
        }

        // Text Functions
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Error(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Country(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Country.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Country.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Country.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Country.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Country.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Country.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Province(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Municipality(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Municipality.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Municipality.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Municipality.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Municipality.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Municipality.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Municipality.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Street_Name(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Street_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Street_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Street_Number(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Street_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Street_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Street_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Postal_Code(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Postal_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Postal_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Postal_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Postal_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Postal_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Postal_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Google_Address_Text(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Google_Address_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Google_Address_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Google_Address_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Google_Address_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Google_Address_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Google_Address_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Contact_Name(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Last_Update_Contact_Initial(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => String.Compare(c.Infrastructure_Address_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }

        // Number Functions
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_Counter(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
        public IQueryable<ReportInfrastructure_AddressModel> ReportServiceGeneratedInfrastructure_Address_Infrastructure_Address_ID(IQueryable<ReportInfrastructure_AddressModel> reportInfrastructure_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructure_AddressModelQ = reportInfrastructure_AddressModelQ.Where(c => c.Infrastructure_Address_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructure_AddressModelQ;
        }
    }
}
