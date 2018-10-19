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
    public partial class ReportServicePol_Source_Site_Address
    {
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Address_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Error);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Error);
                            }
                            break;
                        case "Pol_Source_Site_Address_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Counter);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Counter);
                            }
                            break;
                        case "Pol_Source_Site_Address_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_ID);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_ID);
                            }
                            break;
                        case "Pol_Source_Site_Address_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Type);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Type);
                            }
                            break;
                        case "Pol_Source_Site_Address_Country":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Country);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Country);
                            }
                            break;
                        case "Pol_Source_Site_Address_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Province);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Province);
                            }
                            break;
                        case "Pol_Source_Site_Address_Municipality":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Municipality);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Municipality);
                            }
                            break;
                        case "Pol_Source_Site_Address_Street_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Street_Name);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Street_Name);
                            }
                            break;
                        case "Pol_Source_Site_Address_Street_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Street_Number);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Street_Number);
                            }
                            break;
                        case "Pol_Source_Site_Address_Street_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Street_Type);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Street_Type);
                            }
                            break;
                        case "Pol_Source_Site_Address_Postal_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Postal_Code);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Postal_Code);
                            }
                            break;
                        case "Pol_Source_Site_Address_Google_Address_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Google_Address_Text);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Google_Address_Text);
                            }
                            break;
                        case "Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Pol_Source_Site_Address_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Last_Update_Contact_Name);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Last_Update_Contact_Name);
                            }
                            break;
                        case "Pol_Source_Site_Address_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderBy(c => c.Pol_Source_Site_Address_Last_Update_Contact_Initial);
                                else
                                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.OrderByDescending(c => c.Pol_Source_Site_Address_Last_Update_Contact_Initial);
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
                        case "Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_YEAR(reportPol_Source_Site_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_MONTH(reportPol_Source_Site_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_DAY(reportPol_Source_Site_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_HOUR(reportPol_Source_Site_AddressModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_MINUTE(reportPol_Source_Site_AddressModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Pol_Source_Site_Address_Error":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Error(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Country":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Country(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Province":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Province(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Municipality":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Municipality(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Street_Name":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Street_Name(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Street_Number":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Street_Number(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Postal_Code":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Postal_Code(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Google_Address_Text":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Google_Address_Text(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Last_Update_Contact_Name":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Contact_Name(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Address_Last_Update_Contact_Initial":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Contact_Initial(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Pol_Source_Site_Address_Counter":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Counter(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Address_ID":
                            reportPol_Source_Site_AddressModelQ = ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_ID(reportPol_Source_Site_AddressModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Pol_Source_Site_Address_Type":
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
                                reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => AddressTypeEqualList.Contains((AddressTypeEnum)c.Pol_Source_Site_Address_Type));
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
                        case "Pol_Source_Site_Address_Street_Type":
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
                                reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => StreetTypeEqualList.Contains((StreetTypeEnum)c.Pol_Source_Site_Address_Street_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter StreetTypeEnum
            return reportPol_Source_Site_AddressModelQ;
        }

        // Date Functions
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_AddressModelQ;
        }

        // Text Functions
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Error(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Country(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Country.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Country.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Country.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Country.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Country.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Country.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Province(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Municipality(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Municipality.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Municipality.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Municipality.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Municipality.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Municipality.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Municipality.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Street_Name(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Street_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Street_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Street_Number(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Street_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Street_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Street_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Postal_Code(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Postal_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Postal_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Postal_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Postal_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Postal_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Postal_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Google_Address_Text(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Google_Address_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Google_Address_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Google_Address_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Google_Address_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Google_Address_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Google_Address_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Contact_Name(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Last_Update_Contact_Initial(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => String.Compare(c.Pol_Source_Site_Address_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }

        // Number Functions
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_Counter(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
        public IQueryable<ReportPol_Source_Site_AddressModel> ReportServiceGeneratedPol_Source_Site_Address_Pol_Source_Site_Address_ID(IQueryable<ReportPol_Source_Site_AddressModel> reportPol_Source_Site_AddressModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_AddressModelQ = reportPol_Source_Site_AddressModelQ.Where(c => c.Pol_Source_Site_Address_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_AddressModelQ;
        }
    }
}
