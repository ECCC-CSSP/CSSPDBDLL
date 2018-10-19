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
    public partial class ReportServiceHydrometric_Site
    {
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Hydrometric_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Error);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Error);
                            }
                            break;
                        case "Hydrometric_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Counter);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Counter);
                            }
                            break;
                        case "Hydrometric_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_ID);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_ID);
                            }
                            break;
                        case "Hydrometric_Site_Fed_Site_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Fed_Site_Number);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Fed_Site_Number);
                            }
                            break;
                        case "Hydrometric_Site_Quebec_Site_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Quebec_Site_Number);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Quebec_Site_Number);
                            }
                            break;
                        case "Hydrometric_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Name);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Name);
                            }
                            break;
                        case "Hydrometric_Site_Description":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Description);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Description);
                            }
                            break;
                        case "Hydrometric_Site_Province":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Province);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Province);
                            }
                            break;
                        case "Hydrometric_Site_Elevation_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Elevation_m);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Elevation_m);
                            }
                            break;
                        case "Hydrometric_Site_Start_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Start_Date_Local);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Start_Date_Local);
                            }
                            break;
                        case "Hydrometric_Site_End_Date_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_End_Date_Local);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_End_Date_Local);
                            }
                            break;
                        case "Hydrometric_Site_Time_Offset_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Time_Offset_hour);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Time_Offset_hour);
                            }
                            break;
                        case "Hydrometric_Site_Drainage_Area_km2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Drainage_Area_km2);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Drainage_Area_km2);
                            }
                            break;
                        case "Hydrometric_Site_Is_Natural":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Is_Natural);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Is_Natural);
                            }
                            break;
                        case "Hydrometric_Site_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Is_Active);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Is_Active);
                            }
                            break;
                        case "Hydrometric_Site_Sediment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Sediment);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Sediment);
                            }
                            break;
                        case "Hydrometric_Site_RHBN":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_RHBN);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_RHBN);
                            }
                            break;
                        case "Hydrometric_Site_Real_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Real_Time);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Real_Time);
                            }
                            break;
                        case "Hydrometric_Site_Has_Rating_Curve":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Has_Rating_Curve);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Has_Rating_Curve);
                            }
                            break;
                        case "Hydrometric_Site_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Last_Update_Date_UTC);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Last_Update_Date_UTC);
                            }
                            break;
                        case "Hydrometric_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Last_Update_Contact_Name);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Hydrometric_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Last_Update_Contact_Initial);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Hydrometric_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Lat);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Lat);
                            }
                            break;
                        case "Hydrometric_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderBy(c => c.Hydrometric_Site_Lng);
                                else
                                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.OrderByDescending(c => c.Hydrometric_Site_Lng);
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
                        case "Hydrometric_Site_Start_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_YEAR(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_MONTH(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_DAY(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_HOUR(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_MINUTE(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Hydrometric_Site_End_Date_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_YEAR(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_MONTH(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_DAY(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_HOUR(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_MINUTE(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Hydrometric_Site_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_YEAR(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_MONTH(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_DAY(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_HOUR(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_MINUTE(reportHydrometric_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Hydrometric_Site_Error":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Error(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Fed_Site_Number":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Fed_Site_Number(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Quebec_Site_Number":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Quebec_Site_Number(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Name":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Name(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Description":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Description(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Province":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Province(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Last_Update_Contact_Name":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Contact_Name(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Hydrometric_Site_Last_Update_Contact_Initial":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Contact_Initial(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Hydrometric_Site_Counter":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Counter(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_ID":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_ID(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Elevation_m":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Elevation_m(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Time_Offset_hour":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Time_Offset_hour(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Drainage_Area_km2":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Drainage_Area_km2(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Lat":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Lat(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Hydrometric_Site_Lng":
                            reportHydrometric_SiteModelQ = ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Lng(reportHydrometric_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Hydrometric_Site_Is_Natural":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Is_Natural == true);
                            else
                                reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Is_Natural == false);
                            break;
                        case "Hydrometric_Site_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Is_Active == true);
                            else
                                reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Is_Active == false);
                            break;
                        case "Hydrometric_Site_Sediment":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Sediment == true);
                            else
                                reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Sediment == false);
                            break;
                        case "Hydrometric_Site_RHBN":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_RHBN == true);
                            else
                                reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_RHBN == false);
                            break;
                        case "Hydrometric_Site_Real_Time":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Real_Time == true);
                            else
                                reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Real_Time == false);
                            break;
                        case "Hydrometric_Site_Has_Rating_Curve":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Has_Rating_Curve == true);
                            else
                                reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Has_Rating_Curve == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportHydrometric_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_YEAR(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_YEAR(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_YEAR(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_MONTH(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_MONTH(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_MONTH(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_DAY(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_DAY(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_DAY(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_HOUR(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_HOUR(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_HOUR(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Start_Date_Local_MINUTE(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Start_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_End_Date_Local_MINUTE(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_End_Date_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Date_UTC_MINUTE(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportHydrometric_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Error(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Fed_Site_Number(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Fed_Site_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Fed_Site_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Fed_Site_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Fed_Site_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Fed_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Fed_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Quebec_Site_Number(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Quebec_Site_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Quebec_Site_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Quebec_Site_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Quebec_Site_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Quebec_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Quebec_Site_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Name(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Description(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Description.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Description.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Description.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Description.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Province(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Province.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Province.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Province.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Province.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Province.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Contact_Name(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Last_Update_Contact_Initial(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => String.Compare(c.Hydrometric_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Counter(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_ID(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Elevation_m(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Elevation_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Elevation_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Elevation_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Time_Offset_hour(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Time_Offset_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Time_Offset_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Time_Offset_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Drainage_Area_km2(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Drainage_Area_km2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Drainage_Area_km2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Drainage_Area_km2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Lat(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
        public IQueryable<ReportHydrometric_SiteModel> ReportServiceGeneratedHydrometric_Site_Hydrometric_Site_Lng(IQueryable<ReportHydrometric_SiteModel> reportHydrometric_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportHydrometric_SiteModelQ = reportHydrometric_SiteModelQ.Where(c => c.Hydrometric_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportHydrometric_SiteModelQ;
        }
    }
}
