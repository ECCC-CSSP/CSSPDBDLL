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
    public partial class ReportServiceHydrometric_Site_Data
    {
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Hydrometric_Site_Data_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Error);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Error);
                            }
                            break;
                        case "Hydrometric_Site_Data_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Counter);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Counter);
                            }
                            break;
                        case "Hydrometric_Site_Data_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_ID);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_ID);
                            }
                            break;
                        case "Hydrometric_Site_Data_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Date_Time_Local);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Date_Time_Local);
                            }
                            break;
                        case "Hydrometric_Site_Data_Keep":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Keep);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Keep);
                            }
                            break;
                        case "Hydrometric_Site_Data_Storage_Data_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Storage_Data_Type);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Storage_Data_Type);
                            }
                            break;
                        case "Hydrometric_Site_Data_Discharge_m3_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Discharge_m3_s);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Discharge_m3_s);
                            }
                            break;
                        case "Hydrometric_Site_Data_DischargeEntered_m3_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_DischargeEntered_m3_s);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_DischargeEntered_m3_s);
                            }
                            break;
                        case "Hydrometric_Site_Data_Level_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Level_m);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Level_m);
                            }
                            break;
                        case "Hydrometric_Site_Data_Hourly_Values":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Hourly_Values);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Hourly_Values);
                            }
                            break;
                        case "Hydrometric_Site_Data_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC);
                            }
                            break;
                        case "Hydrometric_Site_Data_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Last_Update_Contact_Name);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Last_Update_Contact_Name);
                            }
                            break;
                        case "Hydrometric_Site_Data_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderBy(c => c.Hydrometric_Site_Data_Last_Update_Contact_Initial);
                                else
                                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.OrderByDescending(c => c.Hydrometric_Site_Data_Last_Update_Contact_Initial);
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
                        case "Hydrometric_Site_Data_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_YEAR(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_MONTH(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_DAY(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_HOUR(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_MINUTE(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Hydrometric_Site_Data_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_YEAR(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_MONTH(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_DAY(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_HOUR(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_MINUTE(reportHydrometric_Site_DataModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Hydrometric_Site_Data_Error":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Error(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Data_Hourly_Values":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Hourly_Values(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Data_Last_Update_Contact_Name":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Contact_Name(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Data_Last_Update_Contact_Initial":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Contact_Initial(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Hydrometric_Site_Data_Counter":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Counter(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Data_ID":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_ID(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Data_Discharge_m3_s":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Discharge_m3_s(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Data_DischargeEntered_m3_s":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_DischargeEntered_m3_s(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Data_Level_m":
                            reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Level_m(reportHydrometric_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Hydrometric_Site_Data_Keep":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Keep == true);
                            else
                                reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Keep == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            #region Filter StorageDataTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.StorageDataType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Hydrometric_Site_Data_Storage_Data_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<StorageDataTypeEnum> StorageDataTypeEqualList = new List<StorageDataTypeEnum>();
                                List<string> StorageDataTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in StorageDataTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((StorageDataTypeEnum)i).ToString())
                                        {
                                            StorageDataTypeEqualList.Add((StorageDataTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        StorageDataTypeEqualList.Add(StorageDataTypeEnum.Error);
                                }
                                reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => StorageDataTypeEqualList.Contains((StorageDataTypeEnum)c.Hydrometric_Site_Data_Storage_Data_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter StorageDataTypeEnum
            return reportHydrometric_Site_DataModelQ;
        }

        // Date Functions
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_YEAR(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_YEAR(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_MONTH(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_MONTH(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_DAY(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_DAY(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_HOUR(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_HOUR(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Date_Time_Local_MINUTE(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Date_UTC_MINUTE(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_Site_DataModelQ;
        }

        // Text Functions
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Error(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Hourly_Values(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Hourly_Values.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Hourly_Values.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Hourly_Values.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Hourly_Values.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Hourly_Values.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Hourly_Values.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Contact_Name(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Last_Update_Contact_Initial(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => String.Compare(c.Hydrometric_Site_Data_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }

        // Number Functions
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Counter(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_ID(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }
        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Discharge_m3_s(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Discharge_m3_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Discharge_m3_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Discharge_m3_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }

        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_DischargeEntered_m3_s(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_DischargeEntered_m3_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_DischargeEntered_m3_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_DischargeEntered_m3_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }

        public IQueryable<ReportHydrometric_Site_DataModel> ReportServiceGeneratedHydrometric_Site_Data_Hydrometric_Site_Data_Level_m(IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Level_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Level_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_Site_DataModelQ = reportHydrometric_Site_DataModelQ.Where(c => c.Hydrometric_Site_Data_Level_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_Site_DataModelQ;
        }
    }
}
