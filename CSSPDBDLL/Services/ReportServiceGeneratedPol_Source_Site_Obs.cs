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
    public partial class ReportServicePol_Source_Site_Obs
    {
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Obs_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Error);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Error);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Counter);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Counter);
                            }
                            break;
                        case "Pol_Source_Site_Obs_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_ID);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_ID);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Observation_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Observation_Date_Local);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Observation_Date_Local);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Inspector_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Inspector_Name);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Inspector_Name);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Inspector_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Inspector_Initial);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Inspector_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Observation_To_Be_Deleted":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Observation_To_Be_Deleted);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Observation_To_Be_Deleted);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Name);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Name);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Initial);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Only_Last":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Only_Last);
                                else
                                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Only_Last);
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
                        case "Pol_Source_Site_Obs_Observation_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_YEAR(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_MONTH(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_DAY(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_HOUR(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_MINUTE(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_YEAR(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_MONTH(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_DAY(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_HOUR(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_MINUTE(reportPol_Source_Site_ObsModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Pol_Source_Site_Obs_Error":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Error(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Inspector_Name":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Inspector_Name(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Inspector_Initial":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Inspector_Initial(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Observation_To_Be_Deleted":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_To_Be_Deleted(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Last_Update_Contact_Name":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Contact_Name(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Last_Update_Contact_Initial":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Contact_Initial(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Pol_Source_Site_Obs_Counter":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Counter(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Obs_ID":
                            reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_ID(reportPol_Source_Site_ObsModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Pol_Source_Site_Obs_Only_Last":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Only_Last == true);
                            else
                                reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Only_Last == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportPol_Source_Site_ObsModelQ;
        }

        // Date Functions
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_YEAR(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_MONTH(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_DAY(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_HOUR(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_Date_Local_MINUTE(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_ObsModelQ;
        }

        // Text Functions
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Error(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Inspector_Name(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Inspector_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Inspector_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Inspector_Initial(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Inspector_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Inspector_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Inspector_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Observation_To_Be_Deleted(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_To_Be_Deleted.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_To_Be_Deleted.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_To_Be_Deleted.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Observation_To_Be_Deleted.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Observation_To_Be_Deleted.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Observation_To_Be_Deleted.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Contact_Name(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Last_Update_Contact_Initial(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }

        // Number Functions
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_Counter(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
        public IQueryable<ReportPol_Source_Site_ObsModel> ReportServiceGeneratedPol_Source_Site_Obs_Pol_Source_Site_Obs_ID(IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_ObsModelQ = reportPol_Source_Site_ObsModelQ.Where(c => c.Pol_Source_Site_Obs_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_ObsModelQ;
        }
    }
}
