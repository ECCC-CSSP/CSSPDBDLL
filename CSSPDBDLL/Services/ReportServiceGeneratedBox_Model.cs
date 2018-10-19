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
    public partial class ReportServiceBox_Model
    {
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Box_Model_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Error);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Error);
                            }
                            break;
                        case "Box_Model_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Counter);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Counter);
                            }
                            break;
                        case "Box_Model_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_ID);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_ID);
                            }
                            break;
                        case "Box_Model_Scenario_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Scenario_Name_Translation_Status);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Scenario_Name_Translation_Status);
                            }
                            break;
                        case "Box_Model_Scenario_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Scenario_Name);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Scenario_Name);
                            }
                            break;
                        case "Box_Model_Flow_m3_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Flow_m3_day);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Flow_m3_day);
                            }
                            break;
                        case "Box_Model_Depth_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Depth_m);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Depth_m);
                            }
                            break;
                        case "Box_Model_Temperature_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Temperature_C);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Temperature_C);
                            }
                            break;
                        case "Box_Model_Dilution":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Dilution);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Dilution);
                            }
                            break;
                        case "Box_Model_Decay_Rate_per_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Decay_Rate_per_day);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Decay_Rate_per_day);
                            }
                            break;
                        case "Box_Model_FC_Untreated_MPN_100ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_FC_Untreated_MPN_100ml);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_FC_Untreated_MPN_100ml);
                            }
                            break;
                        case "Box_Model_FC_Pre_Disinfection_MPN_100_ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_FC_Pre_Disinfection_MPN_100_ml);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_FC_Pre_Disinfection_MPN_100_ml);
                            }
                            break;
                        case "Box_Model_Concentration_MPN_100_ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Concentration_MPN_100_ml);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Concentration_MPN_100_ml);
                            }
                            break;
                        case "Box_Model_T90_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_T90_hour);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_T90_hour);
                            }
                            break;
                        case "Box_Model_Flow_Duration_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Flow_Duration_hour);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Flow_Duration_hour);
                            }
                            break;
                        case "Box_Model_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Last_Update_Date_UTC);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Last_Update_Date_UTC);
                            }
                            break;
                        case "Box_Model_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Last_Update_Contact_Name);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Last_Update_Contact_Name);
                            }
                            break;
                        case "Box_Model_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderBy(c => c.Box_Model_Last_Update_Contact_Initial);
                                else
                                    reportBox_ModelModelQ = reportBox_ModelModelQ.OrderByDescending(c => c.Box_Model_Last_Update_Contact_Initial);
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
                        case "Box_Model_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_YEAR(reportBox_ModelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_MONTH(reportBox_ModelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_DAY(reportBox_ModelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_HOUR(reportBox_ModelModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_MINUTE(reportBox_ModelModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Box_Model_Error":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Error(reportBox_ModelModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Box_Model_Scenario_Name":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Scenario_Name(reportBox_ModelModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Box_Model_Last_Update_Contact_Name":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Contact_Name(reportBox_ModelModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Box_Model_Last_Update_Contact_Initial":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Contact_Initial(reportBox_ModelModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Box_Model_Counter":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Counter(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_ID":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_ID(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Flow_m3_day":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Flow_m3_day(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Depth_m":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Depth_m(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Temperature_C":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Temperature_C(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Dilution":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Dilution(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Decay_Rate_per_day":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Decay_Rate_per_day(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_FC_Untreated_MPN_100ml":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_FC_Untreated_MPN_100ml(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_FC_Pre_Disinfection_MPN_100_ml":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_FC_Pre_Disinfection_MPN_100_ml(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Concentration_MPN_100_ml":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Concentration_MPN_100_ml(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_T90_hour":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_T90_hour(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Flow_Duration_hour":
                            reportBox_ModelModelQ = ReportServiceGeneratedBox_Model_Box_Model_Flow_Duration_hour(reportBox_ModelModelQ, reportTreeNode, dbFilteringNumberField);
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
            #region Filter TranslationStatusEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TranslationStatus))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Box_Model_Scenario_Name_Translation_Status":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TranslationStatusEnum> TranslationStatusEqualList = new List<TranslationStatusEnum>();
                                List<string> TranslationStatusTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TranslationStatusTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TranslationStatusEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TranslationStatusEnum)i).ToString())
                                        {
                                            TranslationStatusEqualList.Add((TranslationStatusEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TranslationStatusEqualList.Add(TranslationStatusEnum.Error);
                                }
                                reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Box_Model_Scenario_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportBox_ModelModelQ;
        }

        // Date Functions
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_YEAR(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_MONTH(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_DAY(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_HOUR(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Date_UTC_MINUTE(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_ModelModelQ;
        }

        // Text Functions
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Error(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Scenario_Name(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Scenario_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Scenario_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Scenario_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Scenario_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Scenario_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Scenario_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Contact_Name(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Last_Update_Contact_Initial(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => String.Compare(c.Box_Model_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }

        // Number Functions
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Counter(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_ID(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Flow_m3_day(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Flow_m3_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Flow_m3_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Flow_m3_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Depth_m(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Depth_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Depth_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Depth_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Temperature_C(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Temperature_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Temperature_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Temperature_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Dilution(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Dilution > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Dilution < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Dilution == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Decay_Rate_per_day(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Decay_Rate_per_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Decay_Rate_per_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Decay_Rate_per_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_FC_Untreated_MPN_100ml(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_FC_Untreated_MPN_100ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_FC_Untreated_MPN_100ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_FC_Untreated_MPN_100ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_FC_Pre_Disinfection_MPN_100_ml(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_FC_Pre_Disinfection_MPN_100_ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_FC_Pre_Disinfection_MPN_100_ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_FC_Pre_Disinfection_MPN_100_ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Concentration_MPN_100_ml(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Concentration_MPN_100_ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Concentration_MPN_100_ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Concentration_MPN_100_ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_T90_hour(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_T90_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_T90_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_T90_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
        public IQueryable<ReportBox_ModelModel> ReportServiceGeneratedBox_Model_Box_Model_Flow_Duration_hour(IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Flow_Duration_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Flow_Duration_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_ModelModelQ = reportBox_ModelModelQ.Where(c => c.Box_Model_Flow_Duration_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_ModelModelQ;
        }
    }
}
