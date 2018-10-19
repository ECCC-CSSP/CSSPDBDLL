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
    public partial class ReportServiceMunicipality
    {
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Municipality_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Error);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Error);
                            }
                            break;
                        case "Municipality_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Counter);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Counter);
                            }
                            break;
                        case "Municipality_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_ID);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_ID);
                            }
                            break;
                        case "Municipality_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Name_Translation_Status);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Name_Translation_Status);
                            }
                            break;
                        case "Municipality_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Name);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Name);
                            }
                            break;
                        case "Municipality_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Is_Active);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Is_Active);
                            }
                            break;
                        case "Municipality_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Municipality_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Last_Update_Contact_Name);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Last_Update_Contact_Name);
                            }
                            break;
                        case "Municipality_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Last_Update_Contact_Initial);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Municipality_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Lat);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Lat);
                            }
                            break;
                        case "Municipality_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Lng);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Lng);
                            }
                            break;
                        case "Municipality_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Stat_Lift_Station_Count);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Municipality_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Stat_WWTP_Count);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Stat_WWTP_Count);
                            }
                            break;
                        case "Municipality_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Stat_Mike_Scenario_Count);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Municipality_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Stat_Box_Model_Scenario_Count);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Municipality_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderBy(c => c.Municipality_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportMunicipalityModelQ = reportMunicipalityModelQ.OrderByDescending(c => c.Municipality_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Municipality_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_YEAR(reportMunicipalityModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_MONTH(reportMunicipalityModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_DAY(reportMunicipalityModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_HOUR(reportMunicipalityModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_MINUTE(reportMunicipalityModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Municipality_Error":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Error(reportMunicipalityModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Name":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Name(reportMunicipalityModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Last_Update_Contact_Name":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Contact_Name(reportMunicipalityModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Municipality_Last_Update_Contact_Initial":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Last_Update_Contact_Initial(reportMunicipalityModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Municipality_Counter":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Counter(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_ID":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_ID(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Lat":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Lat(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Lng":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Lng(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Stat_Lift_Station_Count":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Stat_Lift_Station_Count(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Stat_WWTP_Count":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Stat_WWTP_Count(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Stat_Mike_Scenario_Count":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Stat_Mike_Scenario_Count(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Stat_Box_Model_Scenario_Count":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Stat_Box_Model_Scenario_Count(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Municipality_Stat_Visual_Plumes_Scenario_Count":
                            reportMunicipalityModelQ = ReportServiceGeneratedMunicipality_Municipality_Stat_Visual_Plumes_Scenario_Count(reportMunicipalityModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Municipality_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Is_Active == true);
                            else
                                reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Is_Active == false);
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
                        case "Municipality_Name_Translation_Status":
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
                                reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Municipality_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportMunicipalityModelQ;
        }

        // Date Functions
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMunicipalityModelQ;
        }

        // Text Functions
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Error(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Name(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Contact_Name(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Last_Update_Contact_Initial(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => String.Compare(c.Municipality_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }

        // Number Functions
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Counter(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_ID(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Lat(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Lng(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Stat_Lift_Station_Count(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Stat_WWTP_Count(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Stat_Mike_Scenario_Count(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Stat_Box_Model_Scenario_Count(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
        public IQueryable<ReportMunicipalityModel> ReportServiceGeneratedMunicipality_Municipality_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportMunicipalityModel> reportMunicipalityModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMunicipalityModelQ = reportMunicipalityModelQ.Where(c => c.Municipality_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMunicipalityModelQ;
        }
    }
}
