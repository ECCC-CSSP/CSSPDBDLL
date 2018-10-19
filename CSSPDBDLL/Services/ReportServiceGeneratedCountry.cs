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
    public partial class ReportServiceCountry
    {
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry(IQueryable<ReportCountryModel> reportCountryModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Country_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Error);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Error);
                            }
                            break;
                        case "Country_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Counter);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Counter);
                            }
                            break;
                        case "Country_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_ID);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_ID);
                            }
                            break;
                        case "Country_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Name_Translation_Status);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Name_Translation_Status);
                            }
                            break;
                        case "Country_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Name);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Name);
                            }
                            break;
                        case "Country_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Initial);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Initial);
                            }
                            break;
                        case "Country_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Is_Active);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Is_Active);
                            }
                            break;
                        case "Country_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Last_Update_Date_And_Time_UTC);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Country_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Last_Update_Contact_Name);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Last_Update_Contact_Name);
                            }
                            break;
                        case "Country_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Last_Update_Contact_Initial);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Country_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Lat);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Lat);
                            }
                            break;
                        case "Country_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Lng);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Lng);
                            }
                            break;
                        case "Country_Stat_Province_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Province_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Province_Count);
                            }
                            break;
                        case "Country_Stat_Area_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Area_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Area_Count);
                            }
                            break;
                        case "Country_Stat_Sector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Sector_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Sector_Count);
                            }
                            break;
                        case "Country_Stat_Subsector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Subsector_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Subsector_Count);
                            }
                            break;
                        case "Country_Stat_Municipality_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Municipality_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Municipality_Count);
                            }
                            break;
                        case "Country_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Lift_Station_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Country_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_WWTP_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_WWTP_Count);
                            }
                            break;
                        case "Country_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_MWQM_Sample_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "Country_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_MWQM_Site_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "Country_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_MWQM_Run_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "Country_Stat_Pol_Source_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Pol_Source_Site_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Pol_Source_Site_Count);
                            }
                            break;
                        case "Country_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Mike_Scenario_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Country_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Box_Model_Scenario_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Country_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountryModelQ = reportCountryModelQ.OrderBy(c => c.Country_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportCountryModelQ = reportCountryModelQ.OrderByDescending(c => c.Country_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Country_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_YEAR(reportCountryModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_MONTH(reportCountryModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_DAY(reportCountryModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_HOUR(reportCountryModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_MINUTE(reportCountryModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Country_Error":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Error(reportCountryModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_Name":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Name(reportCountryModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_Initial":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Initial(reportCountryModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_Last_Update_Contact_Name":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Contact_Name(reportCountryModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_Last_Update_Contact_Initial":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Last_Update_Contact_Initial(reportCountryModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Country_Counter":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Counter(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_ID":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_ID(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Lat":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Lat(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Lng":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Lng(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Province_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Province_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Area_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Area_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Sector_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Sector_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Subsector_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Subsector_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Municipality_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Municipality_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Lift_Station_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Lift_Station_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_WWTP_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_WWTP_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_MWQM_Sample_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_MWQM_Sample_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_MWQM_Site_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_MWQM_Site_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_MWQM_Run_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_MWQM_Run_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Pol_Source_Site_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Pol_Source_Site_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Mike_Scenario_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Mike_Scenario_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Box_Model_Scenario_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Box_Model_Scenario_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_Stat_Visual_Plumes_Scenario_Count":
                            reportCountryModelQ = ReportServiceGeneratedCountry_Country_Stat_Visual_Plumes_Scenario_Count(reportCountryModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Country_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Is_Active == true);
                            else
                                reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Is_Active == false);
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
                        case "Country_Name_Translation_Status":
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
                                reportCountryModelQ = reportCountryModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Country_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportCountryModelQ;
        }

        // Date Functions
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportCountryModelQ;
        }

        // Text Functions
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Error(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Name(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Initial(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Contact_Name(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Last_Update_Contact_Initial(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => String.Compare(c.Country_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }

        // Number Functions
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Counter(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_ID(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Lat(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Lng(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Province_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Province_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Province_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Province_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Area_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Area_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Area_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Area_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Sector_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Sector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Sector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Sector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Subsector_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Subsector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Subsector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Subsector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Municipality_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Municipality_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Municipality_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Municipality_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Lift_Station_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_WWTP_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_MWQM_Sample_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_MWQM_Site_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_MWQM_Run_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Pol_Source_Site_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Pol_Source_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Pol_Source_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Pol_Source_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Mike_Scenario_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Box_Model_Scenario_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
        public IQueryable<ReportCountryModel> ReportServiceGeneratedCountry_Country_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportCountryModel> reportCountryModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountryModelQ = reportCountryModelQ.Where(c => c.Country_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountryModelQ;
        }
    }
}
