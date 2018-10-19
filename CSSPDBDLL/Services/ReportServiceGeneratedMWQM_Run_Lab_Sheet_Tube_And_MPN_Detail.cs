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
    public partial class ReportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail
    {
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
                                else
                                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
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
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_YEAR(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MONTH(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_DAY(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_HOUR(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MINUTE(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_YEAR(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MONTH(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_DAY(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_HOUR(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MINUTE(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature":
                            reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature(reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }

        // Date Functions
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_YEAR(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_YEAR(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MONTH(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MONTH(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_DAY(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_DAY(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_HOUR(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_HOUR(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MINUTE(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MINUTE(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }

        // Text Functions
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }

        // Number Functions
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature(IQueryable<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
    }
}
