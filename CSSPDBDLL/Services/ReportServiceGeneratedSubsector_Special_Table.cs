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
    public partial class ReportServiceSubsector_Special_Table
    {
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Special_Table_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Error);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Error);
                            }
                            break;
                        case "Subsector_Special_Table_Last_X_Runs":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Last_X_Runs);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Last_X_Runs);
                            }
                            break;
                        case "Subsector_Special_Table_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Type);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Type);
                            }
                            break;
                        case "Subsector_Special_Table_MWQM_Site_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_MWQM_Site_Is_Active);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_MWQM_Site_Is_Active);
                            }
                            break;
                        case "Subsector_Special_Table_Number_Of_Samples_For_Stat_Max":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Max);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Max);
                            }
                            break;
                        case "Subsector_Special_Table_Number_Of_Samples_For_Stat_Min":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Min);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Min);
                            }
                            break;
                        case "Subsector_Special_Table_Highlight_Above_Min_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Highlight_Above_Min_Number);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Highlight_Above_Min_Number);
                            }
                            break;
                        case "Subsector_Special_Table_Highlight_Below_Max_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Highlight_Below_Max_Number);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Highlight_Below_Max_Number);
                            }
                            break;
                        case "Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation);
                            }
                            break;
                        case "Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part);
                            }
                            break;
                        case "Subsector_Special_Table_MWQM_Site_Name_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_MWQM_Site_Name_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_MWQM_Site_Name_List);
                            }
                            break;
                        case "Subsector_Special_Table_Stat_Letter_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Stat_Letter_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Stat_Letter_List);
                            }
                            break;
                        case "Subsector_Special_Table_MWQM_Run_Date_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_MWQM_Run_Date_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_MWQM_Run_Date_List);
                            }
                            break;
                        case "Subsector_Special_Table_Parameter_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Parameter_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Parameter_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Tide_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Tide_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Tide_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_0_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_0_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_0_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_1_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_1_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_1_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_2_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_2_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_2_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_3_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_3_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_3_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_4_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_4_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_4_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_5_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_5_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_5_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_6_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_6_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_6_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_7_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_7_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_7_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_8_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_8_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_8_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_9_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_9_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_9_Value_List);
                            }
                            break;
                        case "Subsector_Special_Table_Rain_Day_10_Value_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderBy(c => c.Subsector_Special_Table_Rain_Day_10_Value_List);
                                else
                                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.OrderByDescending(c => c.Subsector_Special_Table_Rain_Day_10_Value_List);
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
                        case "Subsector_Special_Table_Error":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Error(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_MWQM_Site_Name_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_MWQM_Site_Name_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Stat_Letter_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Stat_Letter_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_MWQM_Run_Date_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_MWQM_Run_Date_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Parameter_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Parameter_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Tide_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Tide_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_0_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_0_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_1_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_1_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_2_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_2_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_3_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_3_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_4_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_4_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_5_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_5_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_6_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_6_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_7_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_7_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_8_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_8_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_9_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_9_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Special_Table_Rain_Day_10_Value_List":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_10_Value_List(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Special_Table_Last_X_Runs":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Last_X_Runs(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Special_Table_Number_Of_Samples_For_Stat_Max":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Number_Of_Samples_For_Stat_Max(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Special_Table_Number_Of_Samples_For_Stat_Min":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Number_Of_Samples_For_Stat_Min(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Special_Table_Highlight_Above_Min_Number":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Highlight_Above_Min_Number(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Special_Table_Highlight_Below_Max_Number":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Highlight_Below_Max_Number(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part":
                            reportSubsector_Special_TableModelQ = ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part(reportSubsector_Special_TableModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Special_Table_MWQM_Site_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Site_Is_Active == true);
                            else
                                reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Site_Is_Active == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            #region Filter SpecialTableTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.SpecialTableType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Special_Table_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<SpecialTableTypeEnum> SpecialTableTypeEqualList = new List<SpecialTableTypeEnum>();
                                List<string> SpecialTableTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in SpecialTableTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(SpecialTableTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((SpecialTableTypeEnum)i).ToString())
                                        {
                                            SpecialTableTypeEqualList.Add((SpecialTableTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        SpecialTableTypeEqualList.Add(SpecialTableTypeEnum.Error);
                                }
                                reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => SpecialTableTypeEqualList.Contains((SpecialTableTypeEnum)c.Subsector_Special_Table_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter SpecialTableTypeEnum
            return reportSubsector_Special_TableModelQ;
        }

        // Date Functions

        // Text Functions
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Error(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_MWQM_Site_Name_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Site_Name_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Site_Name_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Site_Name_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Site_Name_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_MWQM_Site_Name_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_MWQM_Site_Name_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Stat_Letter_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Stat_Letter_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Stat_Letter_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Stat_Letter_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Stat_Letter_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Stat_Letter_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Stat_Letter_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_MWQM_Run_Date_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Run_Date_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Run_Date_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Run_Date_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_MWQM_Run_Date_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_MWQM_Run_Date_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_MWQM_Run_Date_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Parameter_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Parameter_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Parameter_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Parameter_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Parameter_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Parameter_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Parameter_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Tide_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Tide_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Tide_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Tide_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Tide_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Tide_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Tide_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_0_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_0_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_0_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_0_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_0_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_0_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_0_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_1_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_1_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_1_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_1_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_1_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_1_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_1_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_2_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_2_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_2_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_2_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_2_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_2_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_2_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_3_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_3_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_3_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_3_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_3_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_3_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_3_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_4_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_4_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_4_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_4_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_4_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_4_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_4_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_5_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_5_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_5_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_5_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_5_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_5_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_5_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_6_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_6_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_6_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_6_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_6_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_6_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_6_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_7_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_7_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_7_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_7_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_7_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_7_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_7_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_8_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_8_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_8_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_8_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_8_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_8_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_8_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_9_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_9_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_9_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_9_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_9_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_9_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_9_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Rain_Day_10_Value_List(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_10_Value_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_10_Value_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_10_Value_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Rain_Day_10_Value_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_10_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => String.Compare(c.Subsector_Special_Table_Rain_Day_10_Value_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Last_X_Runs(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Last_X_Runs > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Last_X_Runs < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Last_X_Runs == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Number_Of_Samples_For_Stat_Max(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Max > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Max < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Number_Of_Samples_For_Stat_Min(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Min > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Min < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Highlight_Above_Min_Number(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Highlight_Above_Min_Number > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Highlight_Above_Min_Number < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Highlight_Above_Min_Number == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Highlight_Below_Max_Number(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Highlight_Below_Max_Number > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Highlight_Below_Max_Number < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Highlight_Below_Max_Number == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
        public IQueryable<ReportSubsector_Special_TableModel> ReportServiceGeneratedSubsector_Special_Table_Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part(IQueryable<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Special_TableModelQ = reportSubsector_Special_TableModelQ.Where(c => c.Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Special_TableModelQ;
        }
    }
}
