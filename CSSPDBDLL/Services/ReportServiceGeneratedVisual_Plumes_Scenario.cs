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
    public partial class ReportServiceVisual_Plumes_Scenario
    {
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Visual_Plumes_Scenario_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Error);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Error);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Counter);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Counter);
                            }
                            break;
                        case "Visual_Plumes_Scenario_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_ID);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_ID);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Name_Translation_Status);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Name_Translation_Status);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Name);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Name);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Status);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Status);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Use_As_Best_Estimate":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Use_As_Best_Estimate);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Use_As_Best_Estimate);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Flow_m3_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Effluent_Flow_m3_s);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Effluent_Flow_m3_s);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Froude_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Froude_Number);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Froude_Number);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Port_Diameter_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Port_Diameter_m);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Port_Diameter_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Port_Depth_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Port_Depth_m);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Port_Depth_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Port_Elevation_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Port_Elevation_m);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Port_Elevation_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Vertical_Angle_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Vertical_Angle_deg);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Vertical_Angle_deg);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Horizontal_Angle_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Horizontal_Angle_deg);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Horizontal_Angle_deg);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Number_Of_Ports":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Number_Of_Ports);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Number_Of_Ports);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Port_Spacing_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Port_Spacing_m);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Port_Spacing_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Acute_Mix_Zone_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Acute_Mix_Zone_m);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Acute_Mix_Zone_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Chronic_Mix_Zone_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Chronic_Mix_Zone_m);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Chronic_Mix_Zone_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Salinity_PSU":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Effluent_Salinity_PSU);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Effluent_Salinity_PSU);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Temperature_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Effluent_Temperature_C);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Effluent_Temperature_C);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Velocity_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Effluent_Velocity_m_s);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Effluent_Velocity_m_s);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Raw_Results":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Raw_Results);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Raw_Results);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Name);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Name);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Initial);
                                else
                                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Initial);
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
                        case "Visual_Plumes_Scenario_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_YEAR(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_MONTH(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_DAY(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_HOUR(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_MINUTE(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Visual_Plumes_Scenario_Error":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Error(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Name":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Name(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Raw_Results":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Raw_Results(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Last_Update_Contact_Name":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Contact_Name(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Last_Update_Contact_Initial":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Contact_Initial(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Visual_Plumes_Scenario_Counter":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Counter(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_ID":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_ID(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Flow_m3_s":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Flow_m3_s(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Froude_Number":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Froude_Number(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Port_Diameter_m":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Diameter_m(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Port_Depth_m":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Depth_m(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Port_Elevation_m":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Elevation_m(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Vertical_Angle_deg":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Vertical_Angle_deg(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Horizontal_Angle_deg":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Horizontal_Angle_deg(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Number_Of_Ports":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Number_Of_Ports(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Port_Spacing_m":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Spacing_m(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Acute_Mix_Zone_m":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Acute_Mix_Zone_m(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Chronic_Mix_Zone_m":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Chronic_Mix_Zone_m(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Salinity_PSU":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Salinity_PSU(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Temperature_C":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Temperature_C(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Effluent_Velocity_m_s":
                            reportVisual_Plumes_ScenarioModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Velocity_m_s(reportVisual_Plumes_ScenarioModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Visual_Plumes_Scenario_Use_As_Best_Estimate":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Use_As_Best_Estimate == true);
                            else
                                reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Use_As_Best_Estimate == false);
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
                        case "Visual_Plumes_Scenario_Name_Translation_Status":
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
                                reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Visual_Plumes_Scenario_Name_Translation_Status));
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
                        case "Visual_Plumes_Scenario_Status":
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
                                reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => ScenarioStatusEqualList.Contains((ScenarioStatusEnum)c.Visual_Plumes_Scenario_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter ScenarioStatusEnum
            return reportVisual_Plumes_ScenarioModelQ;
        }

        // Date Functions
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_YEAR(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_MONTH(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_DAY(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_HOUR(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Date_UTC_MINUTE(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_ScenarioModelQ;
        }

        // Text Functions
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Error(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Name(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Raw_Results(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Raw_Results.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Raw_Results.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Raw_Results.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Raw_Results.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Raw_Results.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Raw_Results.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Contact_Name(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Last_Update_Contact_Initial(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }

        // Number Functions
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Counter(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_ID(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Flow_m3_s(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Flow_m3_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Flow_m3_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Flow_m3_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Froude_Number(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Froude_Number > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Froude_Number < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Froude_Number == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Diameter_m(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Diameter_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Diameter_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Diameter_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Depth_m(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Depth_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Depth_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Depth_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Elevation_m(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Elevation_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Elevation_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Elevation_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Vertical_Angle_deg(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Vertical_Angle_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Vertical_Angle_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Vertical_Angle_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Horizontal_Angle_deg(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Horizontal_Angle_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Horizontal_Angle_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Horizontal_Angle_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Number_Of_Ports(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Number_Of_Ports > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Number_Of_Ports < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Number_Of_Ports == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Port_Spacing_m(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Spacing_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Spacing_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Port_Spacing_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Acute_Mix_Zone_m(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Acute_Mix_Zone_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Acute_Mix_Zone_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Acute_Mix_Zone_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Chronic_Mix_Zone_m(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Chronic_Mix_Zone_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Chronic_Mix_Zone_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Chronic_Mix_Zone_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Salinity_PSU(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Salinity_PSU > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Salinity_PSU < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Salinity_PSU == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Temperature_C(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Temperature_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Temperature_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Temperature_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
        public IQueryable<ReportVisual_Plumes_ScenarioModel> ReportServiceGeneratedVisual_Plumes_Scenario_Visual_Plumes_Scenario_Effluent_Velocity_m_s(IQueryable<ReportVisual_Plumes_ScenarioModel> reportVisual_Plumes_ScenarioModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Velocity_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Velocity_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_ScenarioModelQ = reportVisual_Plumes_ScenarioModelQ.Where(c => c.Visual_Plumes_Scenario_Effluent_Velocity_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_ScenarioModelQ;
        }
    }
}
