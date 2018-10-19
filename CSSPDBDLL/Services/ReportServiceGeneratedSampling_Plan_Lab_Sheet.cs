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
    public partial class ReportServiceSampling_Plan_Lab_Sheet
    {
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Lab_Sheet_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Error);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Error);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Counter);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Counter);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_ID);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_ID);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Sampling_Plan_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Province);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Province);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_For_Group_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_For_Group_Name);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_For_Group_Name);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Year":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Year);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Year);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Month":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Month);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Month);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Day);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Day);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Access_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Access_Code);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Access_Code);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Subsector_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Subsector_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Sampling_Plan_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Type);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Type);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Sample_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Sample_Type);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Sample_Type);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Lab_Sheet_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Lab_Sheet_Type);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Lab_Sheet_Type);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Status);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Status);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_File_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_File_Name);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_File_Name);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_File_Content":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_File_Content);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_File_Content);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial);
                                else
                                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial);
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
                        case "Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_YEAR(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_MONTH(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_DAY(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_HOUR(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_MINUTE(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_YEAR(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MONTH(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_DAY(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_HOUR(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MINUTE(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_YEAR(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_MONTH(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_DAY(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_HOUR(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_MINUTE(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Sampling_Plan_Lab_Sheet_Error":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Error(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Sampling_Plan_Name":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Sampling_Plan_Name(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Province":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Province(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_For_Group_Name":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_For_Group_Name(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Access_Code":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Access_Code(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Subsector_Name_Short":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Subsector_Name_Short(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Subsector_Name_Long":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Subsector_Name_Long(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Sample_Type":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Sample_Type(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_File_Name":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Name(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_File_Content":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Content(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Sampling_Plan_Lab_Sheet_Counter":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Counter(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_ID":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_ID(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Year":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Year(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Month":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Month(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Day":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Day(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria":
                            reportSampling_Plan_Lab_SheetModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria(reportSampling_Plan_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Sampling_Plan_Lab_Sheet_Sampling_Plan_Type":
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
                                reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => SamplingPlanTypeEqualList.Contains((SamplingPlanTypeEnum)c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Type));
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
                        case "Sampling_Plan_Lab_Sheet_Lab_Sheet_Type":
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
                                reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => LabSheetTypeEqualList.Contains((LabSheetTypeEnum)c.Sampling_Plan_Lab_Sheet_Lab_Sheet_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LabSheetTypeEnum
            #region Filter LabSheetStatusEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.LabSheetStatus))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Lab_Sheet_Status":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<LabSheetStatusEnum> LabSheetStatusEqualList = new List<LabSheetStatusEnum>();
                                List<string> LabSheetStatusTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in LabSheetStatusTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(LabSheetStatusEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((LabSheetStatusEnum)i).ToString())
                                        {
                                            LabSheetStatusEqualList.Add((LabSheetStatusEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        LabSheetStatusEqualList.Add(LabSheetStatusEnum.Error);
                                }
                                reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => LabSheetStatusEqualList.Contains((LabSheetStatusEnum)c.Sampling_Plan_Lab_Sheet_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LabSheetStatusEnum
            return reportSampling_Plan_Lab_SheetModelQ;
        }

        // Date Functions
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_YEAR(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_YEAR(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_MONTH(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_MONTH(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_DAY(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_DAY(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_DAY(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_HOUR(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_HOUR(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local_MINUTE(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_SheetModelQ;
        }

        // Text Functions
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Error(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Sampling_Plan_Name(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Province(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_For_Group_Name(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_For_Group_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_For_Group_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_For_Group_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_For_Group_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Access_Code(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Access_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Access_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Access_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Access_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Subsector_Name_Short(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Subsector_Name_Long(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Sample_Type(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sample_Type.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sample_Type.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sample_Type.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Sample_Type.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Name(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_File_Content(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Content.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Content.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Content.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_File_Content.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_File_Content.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_File_Content.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }

        // Number Functions
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Counter(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_ID(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Year(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Year > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Year < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Year == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Month(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Month > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Month < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Month == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Day(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_SheetModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria(IQueryable<ReportSampling_Plan_Lab_SheetModel> reportSampling_Plan_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_SheetModelQ = reportSampling_Plan_Lab_SheetModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_SheetModelQ;
        }
    }
}
