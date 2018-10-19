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
    public partial class ReportServiceSampling_Plan
    {
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Error);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Error);
                            }
                            break;
                        case "Sampling_Plan_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Counter);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Counter);
                            }
                            break;
                        case "Sampling_Plan_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_ID);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_ID);
                            }
                            break;
                        case "Sampling_Plan_Sampling_Plan_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Sampling_Plan_Name);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Sampling_Plan_Name);
                            }
                            break;
                        case "Sampling_Plan_For_Group_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_For_Group_Name);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_For_Group_Name);
                            }
                            break;
                        case "Sampling_Plan_Sample_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Sample_Type);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Sample_Type);
                            }
                            break;
                        case "Sampling_Plan_Sampling_Plan_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Sampling_Plan_Type);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Sampling_Plan_Type);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Type);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Type);
                            }
                            break;
                        case "Sampling_Plan_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Province);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Province);
                            }
                            break;
                        case "Sampling_Plan_Creator_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Creator_Name);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Creator_Name);
                            }
                            break;
                        case "Sampling_Plan_Creator_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Creator_Initial);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Creator_Initial);
                            }
                            break;
                        case "Sampling_Plan_Year":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Year);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Year);
                            }
                            break;
                        case "Sampling_Plan_Access_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Access_Code);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Access_Code);
                            }
                            break;
                        case "Sampling_Plan_Daily_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Daily_Duplicate_Precision_Criteria);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Daily_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Sampling_Plan_Intertech_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Intertech_Duplicate_Precision_Criteria);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Intertech_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Sampling_Plan_Sampling_Plan_File":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Sampling_Plan_File);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Sampling_Plan_File);
                            }
                            break;
                        case "Sampling_Plan_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Last_Update_Date_UTC);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Last_Update_Date_UTC);
                            }
                            break;
                        case "Sampling_Plan_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Last_Update_Contact_Name);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Last_Update_Contact_Name);
                            }
                            break;
                        case "Sampling_Plan_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderBy(c => c.Sampling_Plan_Last_Update_Contact_Initial);
                                else
                                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.OrderByDescending(c => c.Sampling_Plan_Last_Update_Contact_Initial);
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
                        case "Sampling_Plan_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_YEAR(reportSampling_PlanModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_MONTH(reportSampling_PlanModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_DAY(reportSampling_PlanModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_HOUR(reportSampling_PlanModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_MINUTE(reportSampling_PlanModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Sampling_Plan_Error":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Error(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Sampling_Plan_Name":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Sampling_Plan_Name(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_For_Group_Name":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_For_Group_Name(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Sample_Type":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Sample_Type(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Province":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Province(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Creator_Name":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Creator_Name(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Creator_Initial":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Creator_Initial(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Access_Code":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Access_Code(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Sampling_Plan_File":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Sampling_Plan_File(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Last_Update_Contact_Name":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Contact_Name(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Last_Update_Contact_Initial":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Contact_Initial(reportSampling_PlanModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Sampling_Plan_Counter":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Counter(reportSampling_PlanModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_ID":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_ID(reportSampling_PlanModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Year":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Year(reportSampling_PlanModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Daily_Duplicate_Precision_Criteria":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Daily_Duplicate_Precision_Criteria(reportSampling_PlanModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Intertech_Duplicate_Precision_Criteria":
                            reportSampling_PlanModelQ = ReportServiceGeneratedSampling_Plan_Sampling_Plan_Intertech_Duplicate_Precision_Criteria(reportSampling_PlanModelQ, reportTreeNode, dbFilteringNumberField);
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
            #region Filter SamplingPlanTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.SamplingPlanType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Sampling_Plan_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<SamplingPlanTypeEnum> SamplingPlanTypeEqualList = new List<SamplingPlanTypeEnum>();
                                List<string> SamplingPlanTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in SamplingPlanTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((SamplingPlanTypeEnum)i).ToString())
                                        {
                                            SamplingPlanTypeEqualList.Add((SamplingPlanTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        SamplingPlanTypeEqualList.Add(SamplingPlanTypeEnum.Error);
                                }
                                reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => SamplingPlanTypeEqualList.Contains((SamplingPlanTypeEnum)c.Sampling_Plan_Sampling_Plan_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter SamplingPlanTypeEnum
            #region Filter LabSheetTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.LabSheetType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Lab_Sheet_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<LabSheetTypeEnum> LabSheetTypeEqualList = new List<LabSheetTypeEnum>();
                                List<string> LabSheetTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in LabSheetTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((LabSheetTypeEnum)i).ToString())
                                        {
                                            LabSheetTypeEqualList.Add((LabSheetTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        LabSheetTypeEqualList.Add(LabSheetTypeEnum.Error);
                                }
                                reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => LabSheetTypeEqualList.Contains((LabSheetTypeEnum)c.Sampling_Plan_Lab_Sheet_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LabSheetTypeEnum
            return reportSampling_PlanModelQ;
        }

        // Date Functions
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_YEAR(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_MONTH(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_DAY(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_HOUR(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_PlanModelQ;
        }

        // Text Functions
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Error(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Sampling_Plan_Name(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_For_Group_Name(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_For_Group_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_For_Group_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_For_Group_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_For_Group_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Sample_Type(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sample_Type.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sample_Type.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sample_Type.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sample_Type.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Province(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Creator_Name(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Creator_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Creator_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Creator_Initial(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Creator_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Creator_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Creator_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Access_Code(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Access_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Access_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Access_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Access_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Sampling_Plan_File(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_File.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_File.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_File.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Sampling_Plan_File.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Sampling_Plan_File.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Sampling_Plan_File.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Contact_Name(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Last_Update_Contact_Initial(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => String.Compare(c.Sampling_Plan_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }

        // Number Functions
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Counter(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_ID(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Year(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Year > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Year < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Year == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Daily_Duplicate_Precision_Criteria(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Daily_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Daily_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Daily_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
        public IQueryable<ReportSampling_PlanModel> ReportServiceGeneratedSampling_Plan_Sampling_Plan_Intertech_Duplicate_Precision_Criteria(IQueryable<ReportSampling_PlanModel> reportSampling_PlanModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Intertech_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Intertech_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_PlanModelQ = reportSampling_PlanModelQ.Where(c => c.Sampling_Plan_Intertech_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_PlanModelQ;
        }
    }
}
