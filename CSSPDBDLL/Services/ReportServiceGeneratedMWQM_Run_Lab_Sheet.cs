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
    public partial class ReportServiceMWQM_Run_Lab_Sheet
    {
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Lab_Sheet_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Error);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Error);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Counter);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Counter);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_ID);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_ID);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Sampling_Plan_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Province);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Province);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_For_Group_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_For_Group_Name);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_For_Group_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Year":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Year);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Year);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Month":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Month);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Month);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Day);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Day);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Access_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Access_Code);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Access_Code);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Subsector_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Short);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Short);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Subsector_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Long);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Long);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_MWQM_Run_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_MWQM_Run_Name);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_MWQM_Run_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Sampling_Plan_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Type);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Type);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Sample_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Sample_Type);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Sample_Type);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Type);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Type);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Status);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Status);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_File_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_File_Name);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_File_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_File_Content":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_File_Content);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_File_Content);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial);
                                else
                                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial);
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
                        case "MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_YEAR(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_MONTH(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_DAY(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_HOUR(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_MINUTE(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_YEAR(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MONTH(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_DAY(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_HOUR(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MINUTE(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_YEAR(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_MONTH(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_DAY(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_HOUR(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_MINUTE(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MWQM_Run_Lab_Sheet_Error":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Error(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Sampling_Plan_Name":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Sampling_Plan_Name(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Province":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Province(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_For_Group_Name":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_For_Group_Name(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Access_Code":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Access_Code(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Subsector_Name_Short":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Subsector_Name_Short(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Subsector_Name_Long":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Subsector_Name_Long(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_MWQM_Run_Name":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_MWQM_Run_Name(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Sample_Type":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Sample_Type(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_File_Name":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Name(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_File_Content":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Content(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Last_Update_Contact_Name":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Contact_Name(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MWQM_Run_Lab_Sheet_Counter":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Counter(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_ID":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_ID(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Year":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Year(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Month":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Month(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Day":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Day(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria":
                            reportMWQM_Run_Lab_SheetModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria(reportMWQM_Run_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "MWQM_Run_Lab_Sheet_Sampling_Plan_Type":
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
                                reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => SamplingPlanTypeEqualList.Contains((SamplingPlanTypeEnum)c.MWQM_Run_Lab_Sheet_Sampling_Plan_Type));
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
                        case "MWQM_Run_Lab_Sheet_Type":
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
                                reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => LabSheetTypeEqualList.Contains((LabSheetTypeEnum)c.MWQM_Run_Lab_Sheet_Type));
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
                        case "MWQM_Run_Lab_Sheet_Status":
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
                                reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => LabSheetStatusEqualList.Contains((LabSheetStatusEnum)c.MWQM_Run_Lab_Sheet_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LabSheetStatusEnum
            return reportMWQM_Run_Lab_SheetModelQ;
        }

        // Date Functions
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_YEAR(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_YEAR(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_YEAR(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_MONTH(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MONTH(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_MONTH(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_DAY(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_DAY(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_DAY(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_HOUR(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_HOUR(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_HOUR(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local_MINUTE(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MINUTE(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Date_UTC_MINUTE(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_SheetModelQ;
        }

        // Text Functions
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Error(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Sampling_Plan_Name(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Province(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_For_Group_Name(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_For_Group_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_For_Group_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_For_Group_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_For_Group_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Access_Code(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Access_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Access_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Access_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Access_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Subsector_Name_Short(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Subsector_Name_Long(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Subsector_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_MWQM_Run_Name(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_MWQM_Run_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_MWQM_Run_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_MWQM_Run_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_MWQM_Run_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_MWQM_Run_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_MWQM_Run_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Sample_Type(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sample_Type.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sample_Type.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sample_Type.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Sample_Type.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Name(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_File_Content(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Content.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Content.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Content.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_File_Content.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_File_Content.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_File_Content.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Contact_Name(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }

        // Number Functions
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Counter(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_ID(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Year(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Year > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Year < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Year == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Month(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Month > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Month < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Month == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Day(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_SheetModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria(IQueryable<ReportMWQM_Run_Lab_SheetModel> reportMWQM_Run_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_SheetModelQ = reportMWQM_Run_Lab_SheetModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_SheetModelQ;
        }
    }
}
