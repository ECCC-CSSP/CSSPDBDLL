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
    public partial class ReportServiceMike_Scenario
    {
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Scenario_ErrorInfo":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_ErrorInfo);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_ErrorInfo);
                            }
                            break;
                        case "Mike_Scenario_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Error);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Error);
                            }
                            break;
                        case "Mike_Scenario_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Counter);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Counter);
                            }
                            break;
                        case "Mike_Scenario_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_ID);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_ID);
                            }
                            break;
                        case "Mike_Scenario_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Name_Translation_Status);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Name_Translation_Status);
                            }
                            break;
                        case "Mike_Scenario_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Name);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Name);
                            }
                            break;
                        case "Mike_Scenario_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Is_Active);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Is_Active);
                            }
                            break;
                        case "Mike_Scenario_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Status);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Status);
                            }
                            break;
                        case "Mike_Scenario_Start_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Start_Date_Time_Local);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Start_Date_Time_Local);
                            }
                            break;
                        case "Mike_Scenario_End_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_End_Date_Time_Local);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_End_Date_Time_Local);
                            }
                            break;
                        case "Mike_Scenario_Start_Execution_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Start_Execution_Date_Time_Local);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Start_Execution_Date_Time_Local);
                            }
                            break;
                        case "Mike_Scenario_Execution_Time_min":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Execution_Time_min);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Execution_Time_min);
                            }
                            break;
                        case "Mike_Scenario_Wind_Speed_km_h":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Wind_Speed_km_h);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Wind_Speed_km_h);
                            }
                            break;
                        case "Mike_Scenario_Wind_Direction_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Wind_Direction_deg);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Wind_Direction_deg);
                            }
                            break;
                        case "Mike_Scenario_Decay_Factor_per_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Decay_Factor_per_day);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Decay_Factor_per_day);
                            }
                            break;
                        case "Mike_Scenario_Decay_Is_Constant":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Decay_Is_Constant);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Decay_Is_Constant);
                            }
                            break;
                        case "Mike_Scenario_Decay_Factor_Amplitude":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Decay_Factor_Amplitude);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Decay_Factor_Amplitude);
                            }
                            break;
                        case "Mike_Scenario_Result_Frequency_min":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Result_Frequency_min);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Result_Frequency_min);
                            }
                            break;
                        case "Mike_Scenario_Ambient_Temperature_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Ambient_Temperature_C);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Ambient_Temperature_C);
                            }
                            break;
                        case "Mike_Scenario_Ambient_Salinity_PSU":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Ambient_Salinity_PSU);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Ambient_Salinity_PSU);
                            }
                            break;
                        case "Mike_Scenario_Manning_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Manning_Number);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Manning_Number);
                            }
                            break;
                        case "Mike_Scenario_Number_Of_Elements":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Number_Of_Elements);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Number_Of_Elements);
                            }
                            break;
                        case "Mike_Scenario_Number_Of_Time_Steps":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Number_Of_Time_Steps);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Number_Of_Time_Steps);
                            }
                            break;
                        case "Mike_Scenario_Number_Of_Sigma_Layers":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Number_Of_Sigma_Layers);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Number_Of_Sigma_Layers);
                            }
                            break;
                        case "Mike_Scenario_Number_Of_Z_Layers":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Number_Of_Z_Layers);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Number_Of_Z_Layers);
                            }
                            break;
                        case "Mike_Scenario_Number_Of_Hydro_Output_Parameters":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Number_Of_Hydro_Output_Parameters);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Number_Of_Hydro_Output_Parameters);
                            }
                            break;
                        case "Mike_Scenario_Number_Of_Trans_Output_Parameters":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Number_Of_Trans_Output_Parameters);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Number_Of_Trans_Output_Parameters);
                            }
                            break;
                        case "Mike_Scenario_Estimated_Hydro_File_Size":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Estimated_Hydro_File_Size);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Estimated_Hydro_File_Size);
                            }
                            break;
                        case "Mike_Scenario_Estimated_Trans_File_Size":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Estimated_Trans_File_Size);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Estimated_Trans_File_Size);
                            }
                            break;
                        case "Mike_Scenario_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Mike_Scenario_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Last_Update_Contact_Name);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Last_Update_Contact_Name);
                            }
                            break;
                        case "Mike_Scenario_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderBy(c => c.Mike_Scenario_Last_Update_Contact_Initial);
                                else
                                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.OrderByDescending(c => c.Mike_Scenario_Last_Update_Contact_Initial);
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
                        case "Mike_Scenario_Start_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_YEAR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_MONTH(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_DAY(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_HOUR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_MINUTE(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Mike_Scenario_End_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_YEAR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_MONTH(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_DAY(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_HOUR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_MINUTE(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Mike_Scenario_Start_Execution_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_YEAR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_MONTH(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_DAY(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_HOUR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_MINUTE(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Mike_Scenario_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_YEAR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_MONTH(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_DAY(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_HOUR(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_MINUTE(reportMike_ScenarioModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Mike_Scenario_ErrorInfo":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_ErrorInfo(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_Error":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Error(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_Name":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Name(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_Last_Update_Contact_Name":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Contact_Name(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_Last_Update_Contact_Initial":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Contact_Initial(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Mike_Scenario_Counter":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Counter(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_ID":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_ID(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Execution_Time_min":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Execution_Time_min(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Wind_Speed_km_h":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Wind_Speed_km_h(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Wind_Direction_deg":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Wind_Direction_deg(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Decay_Factor_per_day":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Decay_Factor_per_day(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Decay_Factor_Amplitude":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Decay_Factor_Amplitude(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Result_Frequency_min":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Result_Frequency_min(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Ambient_Temperature_C":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Ambient_Temperature_C(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Ambient_Salinity_PSU":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Ambient_Salinity_PSU(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Manning_Number":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Manning_Number(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Number_Of_Elements":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Elements(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Number_Of_Time_Steps":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Time_Steps(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Number_Of_Sigma_Layers":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Sigma_Layers(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Number_Of_Z_Layers":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Z_Layers(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Number_Of_Hydro_Output_Parameters":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Hydro_Output_Parameters(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Number_Of_Trans_Output_Parameters":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Trans_Output_Parameters(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Estimated_Hydro_File_Size":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Estimated_Hydro_File_Size(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_Estimated_Trans_File_Size":
                            reportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario_Mike_Scenario_Estimated_Trans_File_Size(reportMike_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Mike_Scenario_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Is_Active == true);
                            else
                                reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Is_Active == false);
                            break;
                        case "Mike_Scenario_Decay_Is_Constant":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Is_Constant == true);
                            else
                                reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Is_Constant == false);
                            break;
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
                        case "Mike_Scenario_Name_Translation_Status":
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
                                reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Mike_Scenario_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            #region Filter ScenarioStatusEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.ScenarioStatus))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Scenario_Status":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<ScenarioStatusEnum> ScenarioStatusEqualList = new List<ScenarioStatusEnum>();
                                List<string> ScenarioStatusTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in ScenarioStatusTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(ScenarioStatusEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((ScenarioStatusEnum)i).ToString())
                                        {
                                            ScenarioStatusEqualList.Add((ScenarioStatusEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        ScenarioStatusEqualList.Add(ScenarioStatusEnum.Error);
                                }
                                reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => ScenarioStatusEqualList.Contains((ScenarioStatusEnum)c.Mike_Scenario_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter ScenarioStatusEnum
            return reportMike_ScenarioModelQ;
        }

        // Date Functions
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_YEAR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_YEAR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_YEAR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_MONTH(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_MONTH(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_MONTH(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_DAY(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_DAY(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_DAY(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_HOUR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_HOUR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_HOUR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Date_Time_Local_MINUTE(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_End_Date_Time_Local_MINUTE(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Start_Execution_Date_Time_Local_MINUTE(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Start_Execution_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_ScenarioModelQ;
        }

        // Text Functions
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_ErrorInfo(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ErrorInfo.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ErrorInfo.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ErrorInfo.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ErrorInfo.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_ErrorInfo.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_ErrorInfo.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Error(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Name(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Contact_Name(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Last_Update_Contact_Initial(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => String.Compare(c.Mike_Scenario_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }

        // Number Functions
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Counter(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_ID(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Execution_Time_min(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Execution_Time_min > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Execution_Time_min < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Execution_Time_min == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Wind_Speed_km_h(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Wind_Speed_km_h > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Wind_Speed_km_h < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Wind_Speed_km_h == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Wind_Direction_deg(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Wind_Direction_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Wind_Direction_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Wind_Direction_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Decay_Factor_per_day(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Factor_per_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Factor_per_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Factor_per_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Decay_Factor_Amplitude(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Factor_Amplitude > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Factor_Amplitude < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Decay_Factor_Amplitude == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Result_Frequency_min(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Result_Frequency_min > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Result_Frequency_min < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Result_Frequency_min == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Ambient_Temperature_C(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Ambient_Temperature_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Ambient_Temperature_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Ambient_Temperature_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Ambient_Salinity_PSU(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Ambient_Salinity_PSU > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Ambient_Salinity_PSU < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Ambient_Salinity_PSU == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Manning_Number(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Manning_Number > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Manning_Number < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Manning_Number == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Elements(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Elements > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Elements < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Elements == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Time_Steps(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Time_Steps > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Time_Steps < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Time_Steps == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Sigma_Layers(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Sigma_Layers > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Sigma_Layers < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Sigma_Layers == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Z_Layers(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Z_Layers > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Z_Layers < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Z_Layers == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Hydro_Output_Parameters(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Hydro_Output_Parameters > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Hydro_Output_Parameters < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Hydro_Output_Parameters == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Number_Of_Trans_Output_Parameters(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Trans_Output_Parameters > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Trans_Output_Parameters < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Number_Of_Trans_Output_Parameters == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Estimated_Hydro_File_Size(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Estimated_Hydro_File_Size > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Estimated_Hydro_File_Size < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Estimated_Hydro_File_Size == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
        public IQueryable<ReportMike_ScenarioModel> ReportServiceGeneratedMike_Scenario_Mike_Scenario_Estimated_Trans_File_Size(IQueryable<ReportMike_ScenarioModel> reportMike_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Estimated_Trans_File_Size > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Estimated_Trans_File_Size < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_ScenarioModelQ = reportMike_ScenarioModelQ.Where(c => c.Mike_Scenario_Estimated_Trans_File_Size == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_ScenarioModelQ;
        }
    }
}
