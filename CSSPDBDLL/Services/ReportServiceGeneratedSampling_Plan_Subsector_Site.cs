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
    public partial class ReportServiceSampling_Plan_Subsector_Site
    {
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Subsector_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Error);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Error);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Counter);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Counter);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_ID);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_ID);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_MWQM_Site":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_MWQM_Site);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_MWQM_Site);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Is_Duplicate":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Is_Duplicate);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Is_Duplicate);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Lat);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Lat);
                            }
                            break;
                        case "Sampling_Plan_Subsector_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderBy(c => c.Sampling_Plan_Subsector_Site_Lng);
                                else
                                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.OrderByDescending(c => c.Sampling_Plan_Subsector_Site_Lng);
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
                        case "Sampling_Plan_Subsector_Site_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_YEAR(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_MONTH(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_DAY(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_HOUR(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_MINUTE(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Sampling_Plan_Subsector_Site_Error":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Error(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Site_MWQM_Site":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_MWQM_Site(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Site_Last_Update_Contact_Name":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Contact_Name(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Sampling_Plan_Subsector_Site_Counter":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Counter(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Subsector_Site_ID":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_ID(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Subsector_Site_Lat":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Lat(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Subsector_Site_Lng":
                            reportSampling_Plan_Subsector_SiteModelQ = ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Lng(reportSampling_Plan_Subsector_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Sampling_Plan_Subsector_Site_Is_Duplicate":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Is_Duplicate == true);
                            else
                                reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Is_Duplicate == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportSampling_Plan_Subsector_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_YEAR(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_MONTH(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_DAY(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_HOUR(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Subsector_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Error(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_MWQM_Site(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_MWQM_Site.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_MWQM_Site.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_MWQM_Site.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_MWQM_Site.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_MWQM_Site.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_MWQM_Site.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Contact_Name(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => String.Compare(c.Sampling_Plan_Subsector_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Counter(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_ID(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Lat(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
        public IQueryable<ReportSampling_Plan_Subsector_SiteModel> ReportServiceGeneratedSampling_Plan_Subsector_Site_Sampling_Plan_Subsector_Site_Lng(IQueryable<ReportSampling_Plan_Subsector_SiteModel> reportSampling_Plan_Subsector_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Subsector_SiteModelQ = reportSampling_Plan_Subsector_SiteModelQ.Where(c => c.Sampling_Plan_Subsector_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Subsector_SiteModelQ;
        }
    }
}
