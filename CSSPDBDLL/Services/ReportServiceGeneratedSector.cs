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
    public partial class ReportServiceSector
    {
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector(IQueryable<ReportSectorModel> reportSectorModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sector_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Error);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Error);
                            }
                            break;
                        case "Sector_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Counter);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Counter);
                            }
                            break;
                        case "Sector_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_ID);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_ID);
                            }
                            break;
                        case "Sector_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Name_Translation_Status);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Name_Translation_Status);
                            }
                            break;
                        case "Sector_Name_Short":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Name_Short);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Name_Short);
                            }
                            break;
                        case "Sector_Name_Long":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Name_Long);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Name_Long);
                            }
                            break;
                        case "Sector_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Is_Active);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Is_Active);
                            }
                            break;
                        case "Sector_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Last_Update_Date_And_Time_UTC);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Sector_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Last_Update_Contact_Name);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Last_Update_Contact_Name);
                            }
                            break;
                        case "Sector_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Last_Update_Contact_Initial);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Sector_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Lat);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Lat);
                            }
                            break;
                        case "Sector_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Lng);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Lng);
                            }
                            break;
                        case "Sector_Stat_Subsector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Subsector_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Subsector_Count);
                            }
                            break;
                        case "Sector_Stat_Municipality_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Municipality_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Municipality_Count);
                            }
                            break;
                        case "Sector_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Lift_Station_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Sector_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_WWTP_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_WWTP_Count);
                            }
                            break;
                        case "Sector_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_MWQM_Sample_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "Sector_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_MWQM_Site_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "Sector_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_MWQM_Run_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "Sector_Stat_Pol_Source_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Pol_Source_Site_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Pol_Source_Site_Count);
                            }
                            break;
                        case "Sector_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Mike_Scenario_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Sector_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Box_Model_Scenario_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Sector_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSectorModelQ = reportSectorModelQ.OrderBy(c => c.Sector_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportSectorModelQ = reportSectorModelQ.OrderByDescending(c => c.Sector_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Sector_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_YEAR(reportSectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_MONTH(reportSectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_DAY(reportSectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_HOUR(reportSectorModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_MINUTE(reportSectorModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Sector_Error":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Error(reportSectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sector_Name_Short":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Name_Short(reportSectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sector_Name_Long":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Name_Long(reportSectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sector_Last_Update_Contact_Name":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Contact_Name(reportSectorModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sector_Last_Update_Contact_Initial":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Last_Update_Contact_Initial(reportSectorModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Sector_Counter":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Counter(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_ID":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_ID(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Lat":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Lat(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Lng":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Lng(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Subsector_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Subsector_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Municipality_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Municipality_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Lift_Station_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Lift_Station_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_WWTP_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_WWTP_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_MWQM_Sample_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_MWQM_Sample_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_MWQM_Site_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_MWQM_Site_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_MWQM_Run_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_MWQM_Run_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Pol_Source_Site_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Pol_Source_Site_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Mike_Scenario_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Mike_Scenario_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Box_Model_Scenario_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Box_Model_Scenario_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sector_Stat_Visual_Plumes_Scenario_Count":
                            reportSectorModelQ = ReportServiceGeneratedSector_Sector_Stat_Visual_Plumes_Scenario_Count(reportSectorModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Sector_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Is_Active == true);
                            else
                                reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Is_Active == false);
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
                        case "Sector_Name_Translation_Status":
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
                                reportSectorModelQ = reportSectorModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Sector_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportSectorModelQ;
        }

        // Date Functions
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSectorModelQ;
        }

        // Text Functions
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Error(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Name_Short(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Short.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Short.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Short.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Short.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Name_Short.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Name_Long(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Long.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Long.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Long.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Name_Long.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Name_Long.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Contact_Name(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Last_Update_Contact_Initial(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => String.Compare(c.Sector_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }

        // Number Functions
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Counter(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_ID(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Lat(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Lng(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Subsector_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Subsector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Subsector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Subsector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Municipality_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Municipality_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Municipality_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Municipality_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Lift_Station_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_WWTP_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_MWQM_Sample_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_MWQM_Site_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_MWQM_Run_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Pol_Source_Site_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Pol_Source_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Pol_Source_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Pol_Source_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Mike_Scenario_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Box_Model_Scenario_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
        public IQueryable<ReportSectorModel> ReportServiceGeneratedSector_Sector_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportSectorModel> reportSectorModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSectorModelQ = reportSectorModelQ.Where(c => c.Sector_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSectorModelQ;
        }
    }
}
