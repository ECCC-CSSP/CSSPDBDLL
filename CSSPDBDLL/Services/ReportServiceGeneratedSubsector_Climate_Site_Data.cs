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
    public partial class ReportServiceSubsector_Climate_Site_Data
    {
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Climate_Site_Data_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Error);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Error);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Counter);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Counter);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_ID);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_ID);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Date_Time_Local);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Date_Time_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Keep":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Keep);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Keep);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Storage_Data_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Storage_Data_Type);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Storage_Data_Type);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Snow_cm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Snow_cm);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Snow_cm);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Rainfall_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Rainfall_mm);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Rainfall_mm);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Rainfall_Entered_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Rainfall_Entered_mm);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Rainfall_Entered_mm);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Total_Precip_mm_cm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Total_Precip_mm_cm);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Total_Precip_mm_cm);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Max_Temp_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Max_Temp_C);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Max_Temp_C);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Min_Temp_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Min_Temp_C);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Min_Temp_C);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Heat_Deg_Days_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Heat_Deg_Days_C);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Heat_Deg_Days_C);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Cool_Deg_Days_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Cool_Deg_Days_C);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Cool_Deg_Days_C);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Snow_On_Ground_cm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Snow_On_Ground_cm);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Snow_On_Ground_cm);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Dir_Max_Gust_0North":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Dir_Max_Gust_0North);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Dir_Max_Gust_0North);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Spd_Max_Gust_kmh":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Spd_Max_Gust_kmh);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Spd_Max_Gust_kmh);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Hourly_Values":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Hourly_Values);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Hourly_Values);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderBy(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial);
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
                        case "Subsector_Climate_Site_Data_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_YEAR(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_MONTH(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_DAY(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_HOUR(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_MINUTE(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Data_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_YEAR(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_MONTH(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_DAY(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_HOUR(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_MINUTE(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Climate_Site_Data_Error":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Error(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Data_Hourly_Values":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Hourly_Values(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Data_Last_Update_Contact_Name":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Contact_Name(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Data_Last_Update_Contact_Initial":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Contact_Initial(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Climate_Site_Data_Counter":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Counter(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_ID":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_ID(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Snow_cm":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Snow_cm(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Rainfall_mm":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Rainfall_mm(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Rainfall_Entered_mm":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Rainfall_Entered_mm(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Total_Precip_mm_cm":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Total_Precip_mm_cm(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Max_Temp_C":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Max_Temp_C(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Min_Temp_C":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Min_Temp_C(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Heat_Deg_Days_C":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Heat_Deg_Days_C(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Cool_Deg_Days_C":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Cool_Deg_Days_C(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Snow_On_Ground_cm":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Snow_On_Ground_cm(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Dir_Max_Gust_0North":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Dir_Max_Gust_0North(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Data_Spd_Max_Gust_kmh":
                            reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Spd_Max_Gust_kmh(reportSubsector_Climate_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Climate_Site_Data_Keep":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Keep == true);
                            else
                                reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Keep == false);
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
                        case "Subsector_Climate_Site_Data_Storage_Data_Type":
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
                                reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => StorageDataTypeEqualList.Contains((StorageDataTypeEnum)c.Subsector_Climate_Site_Data_Storage_Data_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter StorageDataTypeEnum
            return reportSubsector_Climate_Site_DataModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_YEAR(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_MONTH(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_DAY(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_HOUR(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Date_Time_Local_MINUTE(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_Site_DataModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Error(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Hourly_Values(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Hourly_Values.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Hourly_Values.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Hourly_Values.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Hourly_Values.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Hourly_Values.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Hourly_Values.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Contact_Name(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Data_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Counter(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_ID(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Snow_cm(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Snow_cm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Snow_cm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Snow_cm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Rainfall_mm(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Rainfall_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Rainfall_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Rainfall_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Rainfall_Entered_mm(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Rainfall_Entered_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Rainfall_Entered_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Rainfall_Entered_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Total_Precip_mm_cm(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Total_Precip_mm_cm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Total_Precip_mm_cm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Total_Precip_mm_cm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Max_Temp_C(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Max_Temp_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Max_Temp_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Max_Temp_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Min_Temp_C(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Min_Temp_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Min_Temp_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Min_Temp_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Heat_Deg_Days_C(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Heat_Deg_Days_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Heat_Deg_Days_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Heat_Deg_Days_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Cool_Deg_Days_C(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Cool_Deg_Days_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Cool_Deg_Days_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Cool_Deg_Days_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Snow_On_Ground_cm(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Snow_On_Ground_cm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Snow_On_Ground_cm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Snow_On_Ground_cm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Dir_Max_Gust_0North(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Dir_Max_Gust_0North > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Dir_Max_Gust_0North < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Dir_Max_Gust_0North == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Climate_Site_DataModel> ReportServiceGeneratedSubsector_Climate_Site_Data_Subsector_Climate_Site_Data_Spd_Max_Gust_kmh(IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Spd_Max_Gust_kmh > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Spd_Max_Gust_kmh < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_Site_DataModelQ = reportSubsector_Climate_Site_DataModelQ.Where(c => c.Subsector_Climate_Site_Data_Spd_Max_Gust_kmh == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_Site_DataModelQ;
        }
    }
}
