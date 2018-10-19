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
    public partial class ReportServiceSubsector_Climate_Site
    {
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Climate_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Error);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Error);
                            }
                            break;
                        case "Subsector_Climate_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Counter);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Counter);
                            }
                            break;
                        case "Subsector_Climate_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_ID);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_ID);
                            }
                            break;
                        case "Subsector_Climate_Site_ECDBID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_ECDBID);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_ECDBID);
                            }
                            break;
                        case "Subsector_Climate_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Name);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Name);
                            }
                            break;
                        case "Subsector_Climate_Site_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Province);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Province);
                            }
                            break;
                        case "Subsector_Climate_Site_Elevation_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Elevation_m);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Elevation_m);
                            }
                            break;
                        case "Subsector_Climate_Site_Climate_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Climate_ID);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Climate_ID);
                            }
                            break;
                        case "Subsector_Climate_Site_WMOID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_WMOID);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_WMOID);
                            }
                            break;
                        case "Subsector_Climate_Site_TCID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_TCID);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_TCID);
                            }
                            break;
                        case "Subsector_Climate_Site_Is_Provincial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Is_Provincial);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Is_Provincial);
                            }
                            break;
                        case "Subsector_Climate_Site_Prov_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Prov_Site_ID);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Prov_Site_ID);
                            }
                            break;
                        case "Subsector_Climate_Site_Time_Offset_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Time_Offset_hour);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Time_Offset_hour);
                            }
                            break;
                        case "Subsector_Climate_Site_File_desc":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_File_desc);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_File_desc);
                            }
                            break;
                        case "Subsector_Climate_Site_Hourly_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Hourly_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Hourly_End_Date_Local);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Hourly_End_Date_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Hourly_Now":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Hourly_Now);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Hourly_Now);
                            }
                            break;
                        case "Subsector_Climate_Site_Daily_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Daily_Start_Date_Local);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Daily_Start_Date_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Daily_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Daily_End_Date_Local);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Daily_End_Date_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Daily_Now":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Daily_Now);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Daily_Now);
                            }
                            break;
                        case "Subsector_Climate_Site_Monthly_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Monthly_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Monthly_End_Date_Local);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Monthly_End_Date_Local);
                            }
                            break;
                        case "Subsector_Climate_Site_Monthly_Now":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Monthly_Now);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Monthly_Now);
                            }
                            break;
                        case "Subsector_Climate_Site_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Climate_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Climate_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Subsector_Climate_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Lat);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Lat);
                            }
                            break;
                        case "Subsector_Climate_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderBy(c => c.Subsector_Climate_Site_Lng);
                                else
                                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.OrderByDescending(c => c.Subsector_Climate_Site_Lng);
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
                        case "Subsector_Climate_Site_Hourly_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Hourly_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Daily_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Daily_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Monthly_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Monthly_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Climate_Site_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_YEAR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_MONTH(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_DAY(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_HOUR(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_MINUTE(reportSubsector_Climate_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Climate_Site_Error":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Error(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Name":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Name(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Province":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Province(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Climate_ID":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Climate_ID(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_TCID":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_TCID(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Prov_Site_ID":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Prov_Site_ID(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_File_desc":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_File_desc(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Last_Update_Contact_Name":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Contact_Name(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Climate_Site_Last_Update_Contact_Initial":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Contact_Initial(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Climate_Site_Counter":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Counter(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_ID":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_ID(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_ECDBID":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_ECDBID(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Elevation_m":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Elevation_m(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_WMOID":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_WMOID(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Time_Offset_hour":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Time_Offset_hour(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Lat":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Lat(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Climate_Site_Lng":
                            reportSubsector_Climate_SiteModelQ = ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Lng(reportSubsector_Climate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Climate_Site_Is_Provincial":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Is_Provincial == true);
                            else
                                reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Is_Provincial == false);
                            break;
                        case "Subsector_Climate_Site_Hourly_Now":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Now == true);
                            else
                                reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Now == false);
                            break;
                        case "Subsector_Climate_Site_Daily_Now":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Now == true);
                            else
                                reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Now == false);
                            break;
                        case "Subsector_Climate_Site_Monthly_Now":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Now == true);
                            else
                                reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Now == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportSubsector_Climate_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_Start_Date_Local_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Hourly_End_Date_Local_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_Start_Date_Local_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Daily_End_Date_Local_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_Start_Date_Local_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Monthly_End_Date_Local_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Climate_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Error(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Name(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Province(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Climate_ID(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Climate_ID.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Climate_ID.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Climate_ID.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Climate_ID.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Climate_ID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Climate_ID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_TCID(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_TCID.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_TCID.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_TCID.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_TCID.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_TCID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_TCID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Prov_Site_ID(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Prov_Site_ID.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Prov_Site_ID.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Prov_Site_ID.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Prov_Site_ID.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Prov_Site_ID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Prov_Site_ID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_File_desc(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_File_desc.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_File_desc.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_File_desc.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_File_desc.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_File_desc.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_File_desc.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Contact_Name(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => String.Compare(c.Subsector_Climate_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Counter(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_ID(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_ECDBID(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_ECDBID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_ECDBID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_ECDBID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Elevation_m(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Elevation_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Elevation_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Elevation_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_WMOID(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_WMOID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_WMOID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_WMOID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Time_Offset_hour(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Time_Offset_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Time_Offset_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Time_Offset_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Lat(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Climate_SiteModel> ReportServiceGeneratedSubsector_Climate_Site_Subsector_Climate_Site_Lng(IQueryable<ReportSubsector_Climate_SiteModel> reportSubsector_Climate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Climate_SiteModelQ = reportSubsector_Climate_SiteModelQ.Where(c => c.Subsector_Climate_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Climate_SiteModelQ;
        }
    }
}
