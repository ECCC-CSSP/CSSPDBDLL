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
    public partial class ReportServicePol_Source_Site
    {
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Error);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Error);
                            }
                            break;
                        case "Pol_Source_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Counter);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Counter);
                            }
                            break;
                        case "Pol_Source_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_ID);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_ID);
                            }
                            break;
                        case "Pol_Source_Site_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Name_Translation_Status);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Name_Translation_Status);
                            }
                            break;
                        case "Pol_Source_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Name);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Name);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Sentence":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Filtering":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Filtering);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Filtering);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Risk":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Risk);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Risk);
                            }
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List);
                            }
                            break;
                        case "Pol_Source_Site_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Is_Active);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Is_Active);
                            }
                            break;
                        case "Pol_Source_Site_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Pol_Source_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Update_Contact_Name);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Pol_Source_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Last_Update_Contact_Initial);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Pol_Source_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Lat);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Lat);
                            }
                            break;
                        case "Pol_Source_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Lng);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Lng);
                            }
                            break;
                        case "Pol_Source_Site_Old_Site_Id":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Old_Site_Id);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Old_Site_Id);
                            }
                            break;
                        case "Pol_Source_Site_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Site_ID);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Site_ID);
                            }
                            break;
                        case "Pol_Source_Site_Site":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Site);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Site);
                            }
                            break;
                        case "Pol_Source_Site_Is_Point_Source":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Is_Point_Source);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Is_Point_Source);
                            }
                            break;
                        case "Pol_Source_Site_Inactive_Reason":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Inactive_Reason);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Inactive_Reason);
                            }
                            break;
                        case "Pol_Source_Site_Civic_Address":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Civic_Address);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Civic_Address);
                            }
                            break;
                        case "Pol_Source_Site_Google_Address":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderBy(c => c.Pol_Source_Site_Google_Address);
                                else
                                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.OrderByDescending(c => c.Pol_Source_Site_Google_Address);
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
                        case "Pol_Source_Site_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_YEAR(reportPol_Source_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_MONTH(reportPol_Source_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_DAY(reportPol_Source_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_HOUR(reportPol_Source_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_MINUTE(reportPol_Source_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Pol_Source_Site_Error":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Error(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Name":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Name(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Sentence":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Sentence(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Update_Contact_Name":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Contact_Name(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Last_Update_Contact_Initial":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Contact_Initial(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Civic_Address":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Civic_Address(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Pol_Source_Site_Google_Address":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Google_Address(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Pol_Source_Site_Counter":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Counter(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_ID":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_ID(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Lat":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Lat(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Lng":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Lng(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Old_Site_Id":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Old_Site_Id(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Site_ID":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Site_ID(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Pol_Source_Site_Site":
                            reportPol_Source_SiteModelQ = ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Site(reportPol_Source_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == true);
                            else
                                reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == false);
                            break;
                        case "Pol_Source_Site_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Is_Active == true);
                            else
                                reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Is_Active == false);
                            break;
                        case "Pol_Source_Site_Is_Point_Source":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Is_Point_Source == true);
                            else
                                reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Is_Point_Source == false);
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
                        case "Pol_Source_Site_Name_Translation_Status":
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
                                reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Pol_Source_Site_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            #region Filter PolSourceInactiveReasonEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.PolSourceInactiveReason))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Inactive_Reason":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<PolSourceInactiveReasonEnum> PolSourceInactiveReasonEqualList = new List<PolSourceInactiveReasonEnum>();
                                List<string> PolSourceInactiveReasonTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in PolSourceInactiveReasonTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(PolSourceInactiveReasonEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((PolSourceInactiveReasonEnum)i).ToString())
                                        {
                                            PolSourceInactiveReasonEqualList.Add((PolSourceInactiveReasonEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        PolSourceInactiveReasonEqualList.Add(PolSourceInactiveReasonEnum.Error);
                                }
                                reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => PolSourceInactiveReasonEqualList.Contains((PolSourceInactiveReasonEnum)c.Pol_Source_Site_Inactive_Reason));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter PolSourceInactiveReasonEnum
            #region Filter PolSourceIssueRiskEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.PolSourceIssueRisk))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Pol_Source_Site_Last_Obs_Issue_Risk":
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
                                reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => PolSourceIssueRiskEqualList.Contains((PolSourceIssueRiskEnum)c.Pol_Source_Site_Last_Obs_Issue_Risk));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter PolSourceIssueRiskEnum
            return reportPol_Source_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportPol_Source_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Error(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Name(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text_First_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Second_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Last_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Risk_Text_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Sentence(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Sentence.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Sentence.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Sentence.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Contact_Name(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Update_Contact_Initial(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Civic_Address(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Civic_Address.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Civic_Address.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Civic_Address.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Civic_Address.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Civic_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Civic_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Google_Address(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Google_Address.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Google_Address.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Google_Address.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Google_Address.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Google_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => String.Compare(c.Pol_Source_Site_Google_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Counter(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_ID(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Lat(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Lng(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Old_Site_Id(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Old_Site_Id > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Old_Site_Id < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Old_Site_Id == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Site_ID(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
        public IQueryable<ReportPol_Source_SiteModel> ReportServiceGeneratedPol_Source_Site_Pol_Source_Site_Site(IQueryable<ReportPol_Source_SiteModel> reportPol_Source_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Site > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Site < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportPol_Source_SiteModelQ = reportPol_Source_SiteModelQ.Where(c => c.Pol_Source_Site_Site == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportPol_Source_SiteModelQ;
        }
    }
}
