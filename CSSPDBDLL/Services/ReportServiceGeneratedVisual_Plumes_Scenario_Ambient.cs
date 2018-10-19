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
    public partial class ReportServiceVisual_Plumes_Scenario_Ambient
    {
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Visual_Plumes_Scenario_Ambient_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Error);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Error);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Counter);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Counter);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_ID);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_ID);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Row":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Row);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Row);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Measurement_Depth_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Measurement_Depth_m);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Measurement_Depth_m);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Current_Speed_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Current_Speed_m_s);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Current_Speed_m_s);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Current_Direction_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Current_Direction_deg);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Current_Direction_deg);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name);
                            }
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderBy(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial);
                                else
                                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.OrderByDescending(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial);
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
                        case "Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_YEAR(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_MONTH(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_DAY(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_HOUR(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_MINUTE(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Visual_Plumes_Scenario_Ambient_Error":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Error(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Visual_Plumes_Scenario_Ambient_Counter":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Counter(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_ID":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_ID(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Row":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Row(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Measurement_Depth_m":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Measurement_Depth_m(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Current_Speed_m_s":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Current_Speed_m_s(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Current_Direction_deg":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Current_Direction_deg(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient":
                            reportVisual_Plumes_Scenario_AmbientModelQ = ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient(reportVisual_Plumes_Scenario_AmbientModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }

        // Date Functions
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }

        // Text Functions
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Error(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Ambient_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Ambient_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => String.Compare(c.Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }

        // Number Functions
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Counter(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_ID(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Row(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Row > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Row < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Row == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Measurement_Depth_m(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Measurement_Depth_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Measurement_Depth_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Measurement_Depth_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Current_Speed_m_s(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Current_Speed_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Current_Speed_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Current_Speed_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Current_Direction_deg(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Current_Direction_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Current_Direction_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Current_Direction_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
        public IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> ReportServiceGeneratedVisual_Plumes_Scenario_Ambient_Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient(IQueryable<ReportVisual_Plumes_Scenario_AmbientModel> reportVisual_Plumes_Scenario_AmbientModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportVisual_Plumes_Scenario_AmbientModelQ = reportVisual_Plumes_Scenario_AmbientModelQ.Where(c => c.Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportVisual_Plumes_Scenario_AmbientModelQ;
        }
    }
}
