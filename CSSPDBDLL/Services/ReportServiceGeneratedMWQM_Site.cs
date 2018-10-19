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
    public partial class ReportServiceMWQM_Site
    {
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Error);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Error);
                            }
                            break;
                        case "MWQM_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Counter);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Counter);
                            }
                            break;
                        case "MWQM_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_ID);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_ID);
                            }
                            break;
                        case "MWQM_Site_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Name_Translation_Status);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Name_Translation_Status);
                            }
                            break;
                        case "MWQM_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Name);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Name);
                            }
                            break;
                        case "MWQM_Site_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Is_Active);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Is_Active);
                            }
                            break;
                        case "MWQM_Site_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Number);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Number);
                            }
                            break;
                        case "MWQM_Site_Description":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Description);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Description);
                            }
                            break;
                        case "MWQM_Site_Latest_Classification":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Latest_Classification);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Latest_Classification);
                            }
                            break;
                        case "MWQM_Site_Ordinal":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Ordinal);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Ordinal);
                            }
                            break;
                        case "MWQM_Site_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "MWQM_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Last_Update_Contact_Name);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "MWQM_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Last_Update_Contact_Initial);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "MWQM_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Lat);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Lat);
                            }
                            break;
                        case "MWQM_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Lng);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Lng);
                            }
                            break;
                        case "MWQM_Site_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_MWQM_Run_Count);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "MWQM_Site_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_MWQM_Sample_Count);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "MWQM_Site_Stat_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_GM_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_GM_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_GM_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_Median_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Median_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Median_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_P90_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_P90_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_P90_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_P90_Over_43_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_P90_Over_260_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_Min_FC_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Min_FC_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Min_FC_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_Max_FC_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Max_FC_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Max_FC_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_Min_Year_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Min_Year_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Min_Year_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_Max_Year_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Max_Year_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Max_Year_X_Last_Samples);
                            }
                            break;
                        case "MWQM_Site_Stat_Sample_Count_X_Last_Samples":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderBy(c => c.MWQM_Site_Stat_Sample_Count_X_Last_Samples);
                                else
                                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.OrderByDescending(c => c.MWQM_Site_Stat_Sample_Count_X_Last_Samples);
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
                        case "MWQM_Site_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_YEAR(reportMWQM_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_MONTH(reportMWQM_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_DAY(reportMWQM_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_HOUR(reportMWQM_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_MINUTE(reportMWQM_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MWQM_Site_Error":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Error(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Name":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Name(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Number":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Number(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Description":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Description(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Last_Update_Contact_Name":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Contact_Name(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Site_Last_Update_Contact_Initial":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Contact_Initial(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MWQM_Site_Counter":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Counter(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_ID":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_ID(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Ordinal":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Ordinal(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Lat":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Lat(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Lng":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Lng(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_MWQM_Run_Count":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_MWQM_Run_Count(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_MWQM_Sample_Count":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_MWQM_Sample_Count(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_GM_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_GM_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_Median_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Median_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_P90_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_P90_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_P90_Over_43_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_P90_Over_43_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_P90_Over_260_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_P90_Over_260_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_Min_FC_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Min_FC_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_Max_FC_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Max_FC_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_Min_Year_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Min_Year_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_Max_Year_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Max_Year_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Site_Stat_Sample_Count_X_Last_Samples":
                            reportMWQM_SiteModelQ = ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Sample_Count_X_Last_Samples(reportMWQM_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "MWQM_Site_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Is_Active == true);
                            else
                                reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Is_Active == false);
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
                        case "MWQM_Site_Name_Translation_Status":
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
                                reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.MWQM_Site_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            #region Filter MWQMSiteLatestClassificationEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.MWQMSiteLatestClassification))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Site_Latest_Classification":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<MWQMSiteLatestClassificationEnum> MWQMSiteLatestClassificationEqualList = new List<MWQMSiteLatestClassificationEnum>();
                                List<string> MWQMSiteLatestClassificationTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in MWQMSiteLatestClassificationTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(MWQMSiteLatestClassificationEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((MWQMSiteLatestClassificationEnum)i).ToString())
                                        {
                                            MWQMSiteLatestClassificationEqualList.Add((MWQMSiteLatestClassificationEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        MWQMSiteLatestClassificationEqualList.Add(MWQMSiteLatestClassificationEnum.Error);
                                }
                                reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => MWQMSiteLatestClassificationEqualList.Contains((MWQMSiteLatestClassificationEnum)c.MWQM_Site_Latest_Classification));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter MWQMSiteLatestClassificationEnum
            return reportMWQM_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Error(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Name(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Number(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Description(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Description.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Description.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Description.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Description.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Contact_Name(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Last_Update_Contact_Initial(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => String.Compare(c.MWQM_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Counter(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_ID(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Ordinal(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Ordinal > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Ordinal < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Ordinal == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Lat(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Lng(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_MWQM_Run_Count(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_MWQM_Sample_Count(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_GM_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_GM_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_GM_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_GM_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Median_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Median_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Median_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Median_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_P90_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_P90_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_P90_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_P90_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_P90_Over_43_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Perc_Over_43_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_P90_Over_260_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Perc_Over_260_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Min_FC_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Min_FC_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Min_FC_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Min_FC_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Max_FC_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Max_FC_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Max_FC_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Max_FC_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Min_Year_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Min_Year_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Min_Year_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Min_Year_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Max_Year_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Max_Year_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Max_Year_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Max_Year_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
        public IQueryable<ReportMWQM_SiteModel> ReportServiceGeneratedMWQM_Site_MWQM_Site_Stat_Sample_Count_X_Last_Samples(IQueryable<ReportMWQM_SiteModel> reportMWQM_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Sample_Count_X_Last_Samples > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Sample_Count_X_Last_Samples < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_SiteModelQ = reportMWQM_SiteModelQ.Where(c => c.MWQM_Site_Stat_Sample_Count_X_Last_Samples == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_SiteModelQ;
        }
    }
}
