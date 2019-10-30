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
    public partial class ReportServiceClimate_Site
    {
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Climate_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Error);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Error);
                            }
                            break;
                        case "Climate_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Counter);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Counter);
                            }
                            break;
                        case "Climate_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_ID);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_ID);
                            }
                            break;
                        case "Climate_Site_ECDBID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_ECDBID);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_ECDBID);
                            }
                            break;
                        case "Climate_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Name);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Name);
                            }
                            break;
                        case "Climate_Site_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Province);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Province);
                            }
                            break;
                        case "Climate_Site_Elevation_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Elevation_m);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Elevation_m);
                            }
                            break;
                        case "Climate_Site_Climate_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Climate_ID);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Climate_ID);
                            }
                            break;
                        case "Climate_Site_WMOID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_WMOID);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_WMOID);
                            }
                            break;
                        case "Climate_Site_TCID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_TCID);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_TCID);
                            }
                            break;
                        case "Climate_Site_Is_Quebec_Site":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Is_Quebec_Site);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Is_Quebec_Site);
                            }
                            break;
                        case "Climate_Site_Time_Offset_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Time_Offset_hour);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Time_Offset_hour);
                            }
                            break;
                        case "Climate_Site_File_desc":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_File_desc);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_File_desc);
                            }
                            break;
                        case "Climate_Site_Hourly_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Hourly_Start_Date_Local);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Hourly_Start_Date_Local);
                            }
                            break;
                        case "Climate_Site_Hourly_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Hourly_End_Date_Local);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Hourly_End_Date_Local);
                            }
                            break;
                        case "Climate_Site_Hourly_Now":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Hourly_Now);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Hourly_Now);
                            }
                            break;
                        case "Climate_Site_Daily_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Daily_Start_Date_Local);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Daily_Start_Date_Local);
                            }
                            break;
                        case "Climate_Site_Daily_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Daily_End_Date_Local);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Daily_End_Date_Local);
                            }
                            break;
                        case "Climate_Site_Daily_Now":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Daily_Now);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Daily_Now);
                            }
                            break;
                        case "Climate_Site_Monthly_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Monthly_Start_Date_Local);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Monthly_Start_Date_Local);
                            }
                            break;
                        case "Climate_Site_Monthly_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Monthly_End_Date_Local);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Monthly_End_Date_Local);
                            }
                            break;
                        case "Climate_Site_Monthly_Now":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Monthly_Now);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Monthly_Now);
                            }
                            break;
                        case "Climate_Site_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Last_Update_Date_UTC);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Last_Update_Date_UTC);
                            }
                            break;
                        case "Climate_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Last_Update_Contact_Name);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Climate_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Last_Update_Contact_Initial);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Climate_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Lat);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Lat);
                            }
                            break;
                        case "Climate_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderBy(c => c.Climate_Site_Lng);
                                else
                                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.OrderByDescending(c => c.Climate_Site_Lng);
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
                        case "Climate_Site_Hourly_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Climate_Site_Hourly_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Climate_Site_Daily_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Climate_Site_Daily_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Climate_Site_Monthly_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Climate_Site_Monthly_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Climate_Site_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_YEAR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_MONTH(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_DAY(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_HOUR(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_MINUTE(reportClimate_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Climate_Site_Error":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Error(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_Name":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Name(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_Province":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Province(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_Climate_ID":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Climate_ID(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_TCID":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_TCID(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_File_desc":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_File_desc(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_Last_Update_Contact_Name":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Contact_Name(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Climate_Site_Last_Update_Contact_Initial":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Contact_Initial(reportClimate_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Climate_Site_Counter":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Counter(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_ID":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_ID(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_ECDBID":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_ECDBID(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_Elevation_m":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Elevation_m(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_WMOID":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_WMOID(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_Time_Offset_hour":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Time_Offset_hour(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_Lat":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Lat(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Climate_Site_Lng":
                            reportClimate_SiteModelQ = ReportServiceGeneratedClimate_Site_Climate_Site_Lng(reportClimate_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Climate_Site_Is_Provincial":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Is_Quebec_Site == true);
                            else
                                reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Is_Quebec_Site == false);
                            break;
                        case "Climate_Site_Hourly_Now":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Now == true);
                            else
                                reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Now == false);
                            break;
                        case "Climate_Site_Daily_Now":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Now == true);
                            else
                                reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Now == false);
                            break;
                        case "Climate_Site_Monthly_Now":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Now == true);
                            else
                                reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Now == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportClimate_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_YEAR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_MONTH(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_DAY(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_HOUR(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_Start_Date_Local_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Hourly_End_Date_Local_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Hourly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_Start_Date_Local_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Daily_End_Date_Local_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Daily_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_Start_Date_Local_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Monthly_End_Date_Local_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Monthly_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Date_UTC_MINUTE(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportClimate_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Error(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Name(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Province(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Climate_ID(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Climate_ID.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Climate_ID.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Climate_ID.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Climate_ID.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Climate_ID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Climate_ID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_TCID(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_TCID.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_TCID.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_TCID.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_TCID.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_TCID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_TCID.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_File_desc(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_File_desc.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_File_desc.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_File_desc.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_File_desc.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_File_desc.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_File_desc.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Contact_Name(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Last_Update_Contact_Initial(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => String.Compare(c.Climate_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Counter(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_ID(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_ECDBID(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_ECDBID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_ECDBID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_ECDBID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Elevation_m(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Elevation_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Elevation_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Elevation_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_WMOID(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_WMOID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_WMOID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_WMOID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Time_Offset_hour(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Time_Offset_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Time_Offset_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Time_Offset_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Lat(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
        public IQueryable<ReportClimate_SiteModel> ReportServiceGeneratedClimate_Site_Climate_Site_Lng(IQueryable<ReportClimate_SiteModel> reportClimate_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportClimate_SiteModelQ = reportClimate_SiteModelQ.Where(c => c.Climate_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportClimate_SiteModelQ;
        }
    }
}
