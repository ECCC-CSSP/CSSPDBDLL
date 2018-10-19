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
    public partial class ReportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail
    {
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
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
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_YEAR(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MONTH(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_DAY(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_HOUR(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MINUTE(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_YEAR(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MONTH(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_DAY(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_HOUR(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MINUTE(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature":
                            reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature(reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, reportTreeNode, dbFilteringNumberField);
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
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Tube_And_MPN_Detail_Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature(IQueryable<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ = reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelQ;
        }
    }
}
