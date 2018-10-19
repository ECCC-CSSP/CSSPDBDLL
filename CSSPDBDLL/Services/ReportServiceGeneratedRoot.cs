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
    public partial class ReportServiceRoot
    {
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot(IQueryable<ReportRootModel> reportRootModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Root_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Error);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Error);
                            }
                            break;
                        case "Root_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Counter);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Counter);
                            }
                            break;
                        case "Root_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_ID);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_ID);
                            }
                            break;
                        case "Root_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Name_Translation_Status);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Name_Translation_Status);
                            }
                            break;
                        case "Root_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Name);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Name);
                            }
                            break;
                        case "Root_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Is_Active);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Is_Active);
                            }
                            break;
                        case "Root_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Last_Update_Date_And_Time_UTC);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Root_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Last_Update_Contact_Name);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Last_Update_Contact_Name);
                            }
                            break;
                        case "Root_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Last_Update_Contact_Initial);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Root_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Lat);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Lat);
                            }
                            break;
                        case "Root_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Lng);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Lng);
                            }
                            break;
                        case "Root_Stat_Country_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Country_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Country_Count);
                            }
                            break;
                        case "Root_Stat_Province_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Province_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Province_Count);
                            }
                            break;
                        case "Root_Stat_Area_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Area_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Area_Count);
                            }
                            break;
                        case "Root_Stat_Sector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Sector_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Sector_Count);
                            }
                            break;
                        case "Root_Stat_Subsector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Subsector_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Subsector_Count);
                            }
                            break;
                        case "Root_Stat_Municipality_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Municipality_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Municipality_Count);
                            }
                            break;
                        case "Root_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Lift_Station_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Root_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_WWTP_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_WWTP_Count);
                            }
                            break;
                        case "Root_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_MWQM_Sample_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "Root_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_MWQM_Site_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "Root_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_MWQM_Run_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "Root_Stat_Pol_Source_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Pol_Source_Site_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Pol_Source_Site_Count);
                            }
                            break;
                        case "Root_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Mike_Scenario_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Root_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Box_Model_Scenario_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Root_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportRootModelQ = reportRootModelQ.OrderBy(c => c.Root_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportRootModelQ = reportRootModelQ.OrderByDescending(c => c.Root_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Root_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_YEAR(reportRootModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_MONTH(reportRootModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_DAY(reportRootModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_HOUR(reportRootModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_MINUTE(reportRootModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Root_Error":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Error(reportRootModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Root_Name":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Name(reportRootModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Root_Last_Update_Contact_Name":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Contact_Name(reportRootModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Root_Last_Update_Contact_Initial":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Last_Update_Contact_Initial(reportRootModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Root_Counter":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Counter(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_ID":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_ID(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Lat":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Lat(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Lng":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Lng(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Country_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Country_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Province_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Province_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Area_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Area_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Sector_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Sector_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Subsector_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Subsector_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Municipality_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Municipality_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Lift_Station_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Lift_Station_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_WWTP_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_WWTP_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_MWQM_Sample_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_MWQM_Sample_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_MWQM_Site_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_MWQM_Site_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_MWQM_Run_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_MWQM_Run_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Pol_Source_Site_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Pol_Source_Site_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Mike_Scenario_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Mike_Scenario_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Box_Model_Scenario_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Box_Model_Scenario_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Root_Stat_Visual_Plumes_Scenario_Count":
                            reportRootModelQ = ReportServiceGeneratedRoot_Root_Stat_Visual_Plumes_Scenario_Count(reportRootModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Root_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportRootModelQ = reportRootModelQ.Where(c => c.Root_Is_Active == true);
                            else
                                reportRootModelQ = reportRootModelQ.Where(c => c.Root_Is_Active == false);
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
                        case "Root_Name_Translation_Status":
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
                                reportRootModelQ = reportRootModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Root_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportRootModelQ;
        }

        // Date Functions
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Root_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportRootModelQ;
        }

        // Text Functions
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Error(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Name(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Contact_Name(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Last_Update_Contact_Initial(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => String.Compare(c.Root_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }

        // Number Functions
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Counter(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_ID(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Lat(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Lng(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Country_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Country_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Country_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Country_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Province_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Province_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Province_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Province_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Area_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Area_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Area_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Area_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Sector_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Sector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Sector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Sector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Subsector_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Subsector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Subsector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Subsector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Municipality_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Municipality_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Municipality_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Municipality_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Lift_Station_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_WWTP_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_MWQM_Sample_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_MWQM_Site_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_MWQM_Run_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Pol_Source_Site_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Pol_Source_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Pol_Source_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Pol_Source_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Mike_Scenario_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Box_Model_Scenario_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
        public IQueryable<ReportRootModel> ReportServiceGeneratedRoot_Root_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportRootModel> reportRootModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportRootModelQ = reportRootModelQ.Where(c => c.Root_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportRootModelQ;
        }
    }
}
