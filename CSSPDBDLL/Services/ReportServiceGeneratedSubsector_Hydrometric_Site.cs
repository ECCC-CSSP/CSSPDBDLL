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
    public partial class ReportServiceSubsector_Hydrometric_Site
    {
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Hydrometric_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Error);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Error);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Counter);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Counter);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_ID);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_ID);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Fed_Site_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Fed_Site_Number);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Fed_Site_Number);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Quebec_Site_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Quebec_Site_Number);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Quebec_Site_Number);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Name);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Name);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Description":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Description);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Description);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Province);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Province);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Elevation_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Elevation_m);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Elevation_m);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Start_Date_Local);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Start_Date_Local);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_End_Date_Local);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_End_Date_Local);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Time_Offset_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Time_Offset_hour);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Time_Offset_hour);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Drainage_Area_km2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Drainage_Area_km2);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Drainage_Area_km2);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Is_Natural":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Is_Natural);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Is_Natural);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Is_Active);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Is_Active);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Sediment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Sediment);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Sediment);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_RHBN":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_RHBN);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_RHBN);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Real_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Real_Time);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Real_Time);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Has_Rating_Curve":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Has_Rating_Curve);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Has_Rating_Curve);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Lat);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Lat);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderBy(c => c.Subsector_Hydrometric_Site_Lng);
                                else
                                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.OrderByDescending(c => c.Subsector_Hydrometric_Site_Lng);
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
                        case "Subsector_Hydrometric_Site_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_YEAR(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_MONTH(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_DAY(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_HOUR(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_MINUTE(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_YEAR(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_MONTH(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_DAY(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_HOUR(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_MINUTE(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Hydrometric_Site_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_YEAR(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_MONTH(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_DAY(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_HOUR(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_MINUTE(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Hydrometric_Site_Error":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Error(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Fed_Site_Number":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Fed_Site_Number(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Quebec_Site_Number":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Quebec_Site_Number(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Name":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Name(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Description":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Description(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Province":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Province(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Last_Update_Contact_Name":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Contact_Name(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Hydrometric_Site_Last_Update_Contact_Initial":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Contact_Initial(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Hydrometric_Site_Counter":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Counter(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_ID":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_ID(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_Elevation_m":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Elevation_m(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_Time_Offset_hour":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Time_Offset_hour(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_Drainage_Area_km2":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Drainage_Area_km2(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_Lat":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Lat(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Hydrometric_Site_Lng":
                            reportSubsector_Hydrometric_SiteModelQ = ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Lng(reportSubsector_Hydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Hydrometric_Site_Is_Natural":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Is_Natural == true);
                            else
                                reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Is_Natural == false);
                            break;
                        case "Subsector_Hydrometric_Site_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Is_Active == true);
                            else
                                reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Is_Active == false);
                            break;
                        case "Subsector_Hydrometric_Site_Sediment":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Sediment == true);
                            else
                                reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Sediment == false);
                            break;
                        case "Subsector_Hydrometric_Site_RHBN":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_RHBN == true);
                            else
                                reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_RHBN == false);
                            break;
                        case "Subsector_Hydrometric_Site_Real_Time":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Real_Time == true);
                            else
                                reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Real_Time == false);
                            break;
                        case "Subsector_Hydrometric_Site_Has_Rating_Curve":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Has_Rating_Curve == true);
                            else
                                reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Has_Rating_Curve == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportSubsector_Hydrometric_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_YEAR(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_YEAR(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_MONTH(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_MONTH(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_DAY(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_DAY(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_HOUR(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_HOUR(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Start_Date_Local_MINUTE(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_End_Date_Local_MINUTE(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Hydrometric_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Error(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Fed_Site_Number(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Fed_Site_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Fed_Site_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Fed_Site_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Fed_Site_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Fed_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Fed_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Quebec_Site_Number(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Quebec_Site_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Quebec_Site_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Quebec_Site_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Quebec_Site_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Quebec_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Quebec_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Name(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Description(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Description.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Description.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Description.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Description.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Province(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Contact_Name(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => String.Compare(c.Subsector_Hydrometric_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Counter(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_ID(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Elevation_m(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Elevation_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Elevation_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Elevation_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Time_Offset_hour(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Time_Offset_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Time_Offset_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Time_Offset_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Drainage_Area_km2(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Drainage_Area_km2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Drainage_Area_km2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Drainage_Area_km2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Lat(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Hydrometric_SiteModel> ReportServiceGeneratedSubsector_Hydrometric_Site_Subsector_Hydrometric_Site_Lng(IQueryable<ReportSubsector_Hydrometric_SiteModel> reportSubsector_Hydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Hydrometric_SiteModelQ = reportSubsector_Hydrometric_SiteModelQ.Where(c => c.Subsector_Hydrometric_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Hydrometric_SiteModelQ;
        }
    }
}
