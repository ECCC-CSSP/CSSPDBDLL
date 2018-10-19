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
    public partial class ReportServiceSubsector_Tide_Site_Data
    {
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Tide_Site_Data_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Error);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Error);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Counter);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Counter);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_ID);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_ID);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Date_Time_Local);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Date_Time_Local);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Keep":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Keep);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Keep);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Tide_Data_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Tide_Data_Type);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Tide_Data_Type);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Storage_Data_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Storage_Data_Type);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Storage_Data_Type);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Depth_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Depth_m);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Depth_m);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_U_Velocity_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_U_Velocity_m_s);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_U_Velocity_m_s);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_V_Velocity_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_V_Velocity_m_s);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_V_Velocity_m_s);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Tide_Start":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Tide_Start);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Tide_Start);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Tide_End":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Tide_End);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Tide_End);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderBy(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial);
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
                        case "Subsector_Tide_Site_Data_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_YEAR(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_MONTH(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_DAY(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_HOUR(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_MINUTE(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_YEAR(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_MONTH(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_DAY(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_HOUR(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_MINUTE(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Tide_Site_Data_Error":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Error(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Tide_Site_Data_Last_Update_Contact_Name":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Contact_Name(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Tide_Site_Data_Last_Update_Contact_Initial":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Contact_Initial(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Tide_Site_Data_Counter":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Counter(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Data_ID":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_ID(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Data_Depth_m":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Depth_m(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Data_U_Velocity_m_s":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_U_Velocity_m_s(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Data_V_Velocity_m_s":
                            reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_V_Velocity_m_s(reportSubsector_Tide_Site_DataModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Tide_Site_Data_Keep":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Keep == true);
                            else
                                reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Keep == false);
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
                        case "Subsector_Tide_Site_Data_Storage_Data_Type":
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
                                reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => StorageDataTypeEqualList.Contains((StorageDataTypeEnum)c.Subsector_Tide_Site_Data_Storage_Data_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter StorageDataTypeEnum
            #region Filter TideTextEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TideText))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Tide_Site_Data_Tide_Start":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TideTextEnum> TideTextEqualList = new List<TideTextEnum>();
                                List<string> TideTextTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TideTextTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TideTextEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TideTextEnum)i).ToString())
                                        {
                                            TideTextEqualList.Add((TideTextEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TideTextEqualList.Add(TideTextEnum.Error);
                                }
                                reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => TideTextEqualList.Contains((TideTextEnum)c.Subsector_Tide_Site_Data_Tide_Start));
                            }
                            break;
                        case "Subsector_Tide_Site_Data_Tide_End":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TideTextEnum> TideTextEqualList = new List<TideTextEnum>();
                                List<string> TideTextTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TideTextTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TideTextEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TideTextEnum)i).ToString())
                                        {
                                            TideTextEqualList.Add((TideTextEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TideTextEqualList.Add(TideTextEnum.Error);
                                }
                                reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => TideTextEqualList.Contains((TideTextEnum)c.Subsector_Tide_Site_Data_Tide_End));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TideTextEnum
            #region Filter TideDataTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TideDataType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Tide_Site_Data_Tide_Data_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TideDataTypeEnum> TideDataTypeEqualList = new List<TideDataTypeEnum>();
                                List<string> TideDataTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TideDataTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TideDataTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TideDataTypeEnum)i).ToString())
                                        {
                                            TideDataTypeEqualList.Add((TideDataTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TideDataTypeEqualList.Add(TideDataTypeEnum.Error);
                                }
                                reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => TideDataTypeEqualList.Contains((TideDataTypeEnum)c.Subsector_Tide_Site_Data_Tide_Data_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TideDataTypeEnum
            return reportSubsector_Tide_Site_DataModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_YEAR(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_MONTH(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_DAY(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_HOUR(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Date_Time_Local_MINUTE(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_Site_DataModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Error(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Data_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Data_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Contact_Name(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Data_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Data_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Data_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Counter(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_ID(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_Depth_m(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Depth_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Depth_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_Depth_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_U_Velocity_m_s(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_U_Velocity_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_U_Velocity_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_U_Velocity_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
        public IQueryable<ReportSubsector_Tide_Site_DataModel> ReportServiceGeneratedSubsector_Tide_Site_Data_Subsector_Tide_Site_Data_V_Velocity_m_s(IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_V_Velocity_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_V_Velocity_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_Site_DataModelQ = reportSubsector_Tide_Site_DataModelQ.Where(c => c.Subsector_Tide_Site_Data_V_Velocity_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_Site_DataModelQ;
        }
    }
}
