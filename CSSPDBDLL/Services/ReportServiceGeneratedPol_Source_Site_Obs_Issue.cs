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
    public partial class ReportServicePol_Source_Site_Obs_Issue
    {
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Obs_Issue_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Error);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Error);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Counter);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Counter);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_ID);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_ID);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Text);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Text);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_First_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_Start_Level":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Start_Level);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Start_Level);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_End_Level":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Text_End_Level);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Text_End_Level);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Risk_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Sentence":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Sentence);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Sentence);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Filtering":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Filtering);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Filtering);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Risk":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Risk);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Risk);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Enum_ID_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Enum_ID_List);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Enum_ID_List);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name);
                            }
                            break;
                        case "Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderBy(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial);
                                else
                                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.OrderByDescending(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial);
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
                        case "Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_YEAR(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_MONTH(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_DAY(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_HOUR(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_MINUTE(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Pol_Source_Site_Obs_Issue_Error":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Error(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_First_Initial":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_First_Initial(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Risk_Text":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Risk_Text(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Sentence":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Sentence(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Filtering":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Filtering(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Enum_ID_List":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Enum_ID_List(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Pol_Source_Site_Obs_Issue_Counter":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Counter(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_ID":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_ID(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_Start_Level":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_Start_Level(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Obs_Issue_Items_Text_End_Level":
                            reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_End_Level(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal == true);
                            else
                                reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            #region Filter PolSourceIssueRiskEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.PolSourceIssueRisk))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Obs_Issue_Risk":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<PolSourceIssueRiskEnum> PolSourceIssueRiskEqualList = new List<PolSourceIssueRiskEnum>();
                                List<string> PolSourceIssueRiskTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in PolSourceIssueRiskTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(PolSourceIssueRiskEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((PolSourceIssueRiskEnum)i).ToString())
                                        {
                                            PolSourceIssueRiskEqualList.Add((PolSourceIssueRiskEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        PolSourceIssueRiskEqualList.Add(PolSourceIssueRiskEnum.Error);
                                }
                                reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => PolSourceIssueRiskEqualList.Contains((PolSourceIssueRiskEnum)c.Pol_Source_Site_Obs_Issue_Risk));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter PolSourceIssueRiskEnum
            return reportPol_Source_Site_Obs_IssueModelQ;
        }

        // Date Functions
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_Site_Obs_IssueModelQ;
        }

        // Text Functions
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Error(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_First_Initial(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Risk_Text(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Risk_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Risk_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Sentence(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Sentence.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Sentence.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Sentence.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Sentence.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Sentence.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Sentence.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Filtering(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Filtering.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Filtering.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Filtering.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Filtering.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Filtering.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Filtering.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Enum_ID_List(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Enum_ID_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Enum_ID_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Enum_ID_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Enum_ID_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Enum_ID_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Enum_ID_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => String.Compare(c.Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }

        // Number Functions
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Counter(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_ID(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_Start_Level(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Start_Level > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Start_Level < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_Start_Level == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
        public IQueryable<ReportPol_Source_Site_Obs_IssueModel> ReportServiceGeneratedPol_Source_Site_Obs_Issue_Pol_Source_Site_Obs_Issue_Items_Text_End_Level(IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_End_Level > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_End_Level < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_Site_Obs_IssueModelQ = reportPol_Source_Site_Obs_IssueModelQ.Where(c => c.Pol_Source_Site_Obs_Issue_Items_Text_End_Level == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_Site_Obs_IssueModelQ;
        }
    }
}
