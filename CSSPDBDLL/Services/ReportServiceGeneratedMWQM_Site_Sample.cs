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
    public partial class ReportServiceMWQM_Site_Sample
    {
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Site_Sample_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Error);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Error);
                            }
                            break;
                        case "MWQM_Site_Sample_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Counter);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Counter);
                            }
                            break;
                        case "MWQM_Site_Sample_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_ID);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_ID);
                            }
                            break;
                        case "MWQM_Site_Sample_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Date_Time_Local);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Site_Sample_Depth_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Depth_m);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Depth_m);
                            }
                            break;
                        case "MWQM_Site_Sample_Fec_Col_MPN_100_ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Fec_Col_MPN_100_ml);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Fec_Col_MPN_100_ml);
                            }
                            break;
                        case "MWQM_Site_Sample_Salinity_PPT":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Salinity_PPT);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Salinity_PPT);
                            }
                            break;
                        case "MWQM_Site_Sample_Water_Temp_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Water_Temp_C);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Water_Temp_C);
                            }
                            break;
                        case "MWQM_Site_Sample_PH":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_PH);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_PH);
                            }
                            break;
                        case "MWQM_Site_Sample_Types":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Types);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Types);
                            }
                            break;
                        case "MWQM_Site_Sample_Tube_10":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Tube_10);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Tube_10);
                            }
                            break;
                        case "MWQM_Site_Sample_Tube_1_0":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Tube_1_0);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Tube_1_0);
                            }
                            break;
                        case "MWQM_Site_Sample_Tube_0_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Tube_0_1);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Tube_0_1);
                            }
                            break;
                        case "MWQM_Site_Sample_Processed_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Processed_By);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Processed_By);
                            }
                            break;
                        case "MWQM_Site_Sample_Note_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Note_Translation_Status);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Note_Translation_Status);
                            }
                            break;
                        case "MWQM_Site_Sample_Note":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Note);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Note);
                            }
                            break;
                        case "MWQM_Site_Sample_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "MWQM_Site_Sample_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Last_Update_Contact_Name);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Last_Update_Contact_Name);
                            }
                            break;
                        case "MWQM_Site_Sample_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderBy(c => c.MWQM_Site_Sample_Last_Update_Contact_Initial);
                                else
                                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.OrderByDescending(c => c.MWQM_Site_Sample_Last_Update_Contact_Initial);
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
                        case "MWQM_Site_Sample_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_YEAR(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_MONTH(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_DAY(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_HOUR(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_MINUTE(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Site_Sample_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_YEAR(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_MONTH(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_DAY(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_HOUR(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_MINUTE(reportMWQM_Site_SampleModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MWQM_Site_Sample_Error":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Error(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Sample_Types":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Types(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Sample_Processed_By":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Processed_By(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Sample_Note":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Note(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Sample_Last_Update_Contact_Name":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Contact_Name(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Sample_Last_Update_Contact_Initial":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Contact_Initial(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MWQM_Site_Sample_Counter":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Counter(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_ID":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_ID(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Depth_m":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Depth_m(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Fec_Col_MPN_100_ml":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Fec_Col_MPN_100_ml(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Salinity_PPT":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Salinity_PPT(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Water_Temp_C":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Water_Temp_C(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_PH":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_PH(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Tube_10":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Tube_10(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Tube_1_0":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Tube_1_0(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Sample_Tube_0_1":
                            reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Tube_0_1(reportMWQM_Site_SampleModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "MWQM_Site_Sample_Note_Translation_Status":
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
                                reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.MWQM_Site_Sample_Note_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportMWQM_Site_SampleModelQ;
        }

        // Date Functions
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_YEAR(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_MONTH(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_DAY(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_HOUR(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Site_SampleModelQ;
        }

        // Text Functions
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Error(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Types(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Types.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Types.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Types.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Types.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Types.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Types.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Processed_By(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Processed_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Processed_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Processed_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Processed_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Processed_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Processed_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Note(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Note.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Note.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Note.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Note.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Note.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Note.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Contact_Name(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Last_Update_Contact_Initial(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => String.Compare(c.MWQM_Site_Sample_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }

        // Number Functions
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Counter(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_ID(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Depth_m(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Depth_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Depth_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Depth_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Fec_Col_MPN_100_ml(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Fec_Col_MPN_100_ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Fec_Col_MPN_100_ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Fec_Col_MPN_100_ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Salinity_PPT(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Salinity_PPT > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Salinity_PPT < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Salinity_PPT == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Water_Temp_C(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Water_Temp_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Water_Temp_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Water_Temp_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_PH(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_PH > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_PH < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_PH == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Tube_10(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_10 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_10 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_10 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Tube_1_0(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_1_0 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_1_0 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_1_0 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
        public IQueryable<ReportMWQM_Site_SampleModel> ReportServiceGeneratedMWQM_Site_Sample_MWQM_Site_Sample_Tube_0_1(IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_0_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_0_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Site_SampleModelQ = reportMWQM_Site_SampleModelQ.Where(c => c.MWQM_Site_Sample_Tube_0_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Site_SampleModelQ;
        }
    }
}
