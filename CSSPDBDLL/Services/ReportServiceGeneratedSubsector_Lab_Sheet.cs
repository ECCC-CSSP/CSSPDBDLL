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
    public partial class ReportServiceSubsector_Lab_Sheet
    {
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Lab_Sheet_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Error);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Error);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Counter);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Counter);
                            }
                            break;
                        case "Subsector_Lab_Sheet_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_ID);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_ID);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Sampling_Plan_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Sampling_Plan_Name);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Sampling_Plan_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Province);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Province);
                            }
                            break;
                        case "Subsector_Lab_Sheet_For_Group_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_For_Group_Name);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_For_Group_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Year":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Year);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Year);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Month":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Month);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Month);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Day);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Day);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Access_Code":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Access_Code);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Access_Code);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Subsector_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Subsector_Name_Short);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Subsector_Name_Short);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Subsector_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Subsector_Name_Long);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Subsector_Name_Long);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Sampling_Plan_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Sampling_Plan_Type);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Sampling_Plan_Type);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Sample_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Sample_Type);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Sample_Type);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Type);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Type);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Status);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Status);
                            }
                            break;
                        case "Subsector_Lab_Sheet_File_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_File_Name);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_File_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_File_Last_Modified_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local);
                            }
                            break;
                        case "Subsector_Lab_Sheet_File_Content":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_File_Content);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_File_Content);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Initial);
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
                        case "Subsector_Lab_Sheet_File_Last_Modified_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_YEAR(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_MONTH(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_DAY(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_HOUR(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_MINUTE(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_YEAR(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MONTH(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_DAY(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_HOUR(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MINUTE(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_YEAR(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_MONTH(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_DAY(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_HOUR(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_MINUTE(reportSubsector_Lab_SheetModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Lab_Sheet_Error":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Error(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Sampling_Plan_Name":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Sampling_Plan_Name(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Province":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Province(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_For_Group_Name":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_For_Group_Name(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Access_Code":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Access_Code(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Subsector_Name_Short":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Subsector_Name_Short(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Subsector_Name_Long":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Subsector_Name_Long(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Sample_Type":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Sample_Type(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_File_Name":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Name(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_File_Content":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Content(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Last_Update_Contact_Name":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Contact_Name(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Last_Update_Contact_Initial":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Contact_Initial(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Lab_Sheet_Counter":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Counter(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_ID":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_ID(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Year":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Year(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Month":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Month(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Day":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Day(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria":
                            reportSubsector_Lab_SheetModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria(reportSubsector_Lab_SheetModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Lab_Sheet_Sampling_Plan_Type":
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
                                reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => SamplingPlanTypeEqualList.Contains((SamplingPlanTypeEnum)c.Subsector_Lab_Sheet_Sampling_Plan_Type));
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
                        case "Subsector_Lab_Sheet_Type":
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
                                reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => LabSheetTypeEqualList.Contains((LabSheetTypeEnum)c.Subsector_Lab_Sheet_Type));
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
                        case "Subsector_Lab_Sheet_Status":
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
                                reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => LabSheetStatusEqualList.Contains((LabSheetStatusEnum)c.Subsector_Lab_Sheet_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LabSheetStatusEnum
            return reportSubsector_Lab_SheetModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_YEAR(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_YEAR(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_MONTH(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MONTH(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_DAY(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_DAY(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_HOUR(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_HOUR(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Last_Modified_Date_Local_MINUTE(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Last_Modified_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time_MINUTE(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_SheetModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Error(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Sampling_Plan_Name(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sampling_Plan_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sampling_Plan_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sampling_Plan_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sampling_Plan_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Sampling_Plan_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Province(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_For_Group_Name(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_For_Group_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_For_Group_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_For_Group_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_For_Group_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_For_Group_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Access_Code(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Access_Code.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Access_Code.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Access_Code.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Access_Code.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Access_Code.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Subsector_Name_Short(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Subsector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Subsector_Name_Long(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Subsector_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Subsector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Sample_Type(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sample_Type.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sample_Type.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sample_Type.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Sample_Type.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Name(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_File_Content(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Content.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Content.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Content.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_File_Content.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_File_Content.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_File_Content.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Accepted_Or_Rejected_By_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Contact_Name(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Counter(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_ID(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Year(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Year > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Year < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Year == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Month(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Month > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Month < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Month == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Day(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
        public IQueryable<ReportSubsector_Lab_SheetModel> ReportServiceGeneratedSubsector_Lab_Sheet_Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria(IQueryable<ReportSubsector_Lab_SheetModel> reportSubsector_Lab_SheetModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_SheetModelQ = reportSubsector_Lab_SheetModelQ.Where(c => c.Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_SheetModelQ;
        }
    }
}
