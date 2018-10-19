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
    public partial class ReportServiceMunicipality_Contact_Address
    {
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Municipality_Contact_Address_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Error);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Error);
                            }
                            break;
                        case "Municipality_Contact_Address_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Counter);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Counter);
                            }
                            break;
                        case "Municipality_Contact_Address_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_ID);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_ID);
                            }
                            break;
                        case "Municipality_Contact_Address_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Type);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Type);
                            }
                            break;
                        case "Municipality_Contact_Address_Country":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Country);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Country);
                            }
                            break;
                        case "Municipality_Contact_Address_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Province);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Province);
                            }
                            break;
                        case "Municipality_Contact_Address_Municipality":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Municipality);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Municipality);
                            }
                            break;
                        case "Municipality_Contact_Address_Street_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Street_Name);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Street_Name);
                            }
                            break;
                        case "Municipality_Contact_Address_Street_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Street_Number);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Street_Number);
                            }
                            break;
                        case "Municipality_Contact_Address_Street_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Street_Type);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Street_Type);
                            }
                            break;
                        case "Municipality_Contact_Address_Postal_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Postal_Code);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Postal_Code);
                            }
                            break;
                        case "Municipality_Contact_Address_Google_Address_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Google_Address_Text);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Google_Address_Text);
                            }
                            break;
                        case "Municipality_Contact_Address_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Municipality_Contact_Address_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Last_Update_Contact_Name);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Last_Update_Contact_Name);
                            }
                            break;
                        case "Municipality_Contact_Address_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderBy(c => c.Municipality_Contact_Address_Last_Update_Contact_Initial);
                                else
                                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.OrderByDescending(c => c.Municipality_Contact_Address_Last_Update_Contact_Initial);
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
                        case "Municipality_Contact_Address_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_YEAR(reportMunicipality_Contact_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_MONTH(reportMunicipality_Contact_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_DAY(reportMunicipality_Contact_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_HOUR(reportMunicipality_Contact_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_MINUTE(reportMunicipality_Contact_AddressModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Municipality_Contact_Address_Error":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Error(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Country":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Country(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Province":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Province(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Municipality":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Municipality(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Street_Name":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Street_Name(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Street_Number":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Street_Number(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Postal_Code":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Postal_Code(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Google_Address_Text":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Google_Address_Text(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Last_Update_Contact_Name":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Contact_Name(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Contact_Address_Last_Update_Contact_Initial":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Contact_Initial(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Municipality_Contact_Address_Counter":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Counter(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Contact_Address_ID":
                            reportMunicipality_Contact_AddressModelQ = ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_ID(reportMunicipality_Contact_AddressModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Municipality_Contact_Address_Type":
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
                                reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => AddressTypeEqualList.Contains((AddressTypeEnum)c.Municipality_Contact_Address_Type));
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
                        case "Municipality_Contact_Address_Street_Type":
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
                                reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => StreetTypeEqualList.Contains((StreetTypeEnum)c.Municipality_Contact_Address_Street_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter StreetTypeEnum
            return reportMunicipality_Contact_AddressModelQ;
        }

        // Date Functions
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipality_Contact_AddressModelQ;
        }

        // Text Functions
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Error(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Country(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Country.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Country.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Country.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Country.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Country.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Country.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Province(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Municipality(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Municipality.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Municipality.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Municipality.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Municipality.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Municipality.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Municipality.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Street_Name(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Street_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Street_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Street_Number(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Street_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Street_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Street_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Postal_Code(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Postal_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Postal_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Postal_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Postal_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Postal_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Postal_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Google_Address_Text(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Google_Address_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Google_Address_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Google_Address_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Google_Address_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Google_Address_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Google_Address_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Contact_Name(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Last_Update_Contact_Initial(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => String.Compare(c.Municipality_Contact_Address_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }

        // Number Functions
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_Counter(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
        public IQueryable<ReportMunicipality_Contact_AddressModel> ReportServiceGeneratedMunicipality_Contact_Address_Municipality_Contact_Address_ID(IQueryable<ReportMunicipality_Contact_AddressModel> reportMunicipality_Contact_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipality_Contact_AddressModelQ = reportMunicipality_Contact_AddressModelQ.Where(c => c.Municipality_Contact_Address_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipality_Contact_AddressModelQ;
        }
    }
}
