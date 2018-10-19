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
    public partial class ReportServiceProvince
    {
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince(IQueryable<ReportProvinceModel> reportProvinceModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Province_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Error);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Error);
                            }
                            break;
                        case "Province_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Counter);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Counter);
                            }
                            break;
                        case "Province_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_ID);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_ID);
                            }
                            break;
                        case "Province_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Name_Translation_Status);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Name_Translation_Status);
                            }
                            break;
                        case "Province_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Name);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Name);
                            }
                            break;
                        case "Province_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Initial);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Initial);
                            }
                            break;
                        case "Province_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Is_Active);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Is_Active);
                            }
                            break;
                        case "Province_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Last_Update_Date_And_Time_UTC);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Province_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Last_Update_Contact_Name);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Last_Update_Contact_Name);
                            }
                            break;
                        case "Province_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Last_Update_Contact_Initial);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Province_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Lat);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Lat);
                            }
                            break;
                        case "Province_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Lng);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Lng);
                            }
                            break;
                        case "Province_Stat_Area_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Area_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Area_Count);
                            }
                            break;
                        case "Province_Stat_Sector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Sector_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Sector_Count);
                            }
                            break;
                        case "Province_Stat_Subsector_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Subsector_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Subsector_Count);
                            }
                            break;
                        case "Province_Stat_Municipality_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Municipality_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Municipality_Count);
                            }
                            break;
                        case "Province_Stat_Lift_Station_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Lift_Station_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Lift_Station_Count);
                            }
                            break;
                        case "Province_Stat_WWTP_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_WWTP_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_WWTP_Count);
                            }
                            break;
                        case "Province_Stat_MWQM_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_MWQM_Sample_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_MWQM_Sample_Count);
                            }
                            break;
                        case "Province_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_MWQM_Site_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "Province_Stat_MWQM_Run_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_MWQM_Run_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_MWQM_Run_Count);
                            }
                            break;
                        case "Province_Stat_Pol_Source_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Pol_Source_Site_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Pol_Source_Site_Count);
                            }
                            break;
                        case "Province_Stat_Mike_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Mike_Scenario_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Mike_Scenario_Count);
                            }
                            break;
                        case "Province_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Box_Model_Scenario_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Province_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportProvinceModelQ = reportProvinceModelQ.OrderBy(c => c.Province_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportProvinceModelQ = reportProvinceModelQ.OrderByDescending(c => c.Province_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Province_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_YEAR(reportProvinceModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_MONTH(reportProvinceModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_DAY(reportProvinceModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_HOUR(reportProvinceModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_MINUTE(reportProvinceModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Province_Error":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Error(reportProvinceModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Province_Name":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Name(reportProvinceModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Province_Initial":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Initial(reportProvinceModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Province_Last_Update_Contact_Name":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Contact_Name(reportProvinceModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Province_Last_Update_Contact_Initial":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Last_Update_Contact_Initial(reportProvinceModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Province_Counter":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Counter(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_ID":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_ID(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Lat":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Lat(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Lng":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Lng(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Area_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Area_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Sector_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Sector_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Subsector_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Subsector_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Municipality_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Municipality_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Lift_Station_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Lift_Station_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_WWTP_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_WWTP_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_MWQM_Sample_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_MWQM_Sample_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_MWQM_Site_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_MWQM_Site_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_MWQM_Run_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_MWQM_Run_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Pol_Source_Site_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Pol_Source_Site_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Mike_Scenario_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Mike_Scenario_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Box_Model_Scenario_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Box_Model_Scenario_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Province_Stat_Visual_Plumes_Scenario_Count":
                            reportProvinceModelQ = ReportServiceGeneratedProvince_Province_Stat_Visual_Plumes_Scenario_Count(reportProvinceModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Province_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Is_Active == true);
                            else
                                reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Is_Active == false);
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
                        case "Province_Name_Translation_Status":
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
                                reportProvinceModelQ = reportProvinceModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Province_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportProvinceModelQ;
        }

        // Date Functions
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Province_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportProvinceModelQ;
        }

        // Text Functions
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Error(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Name(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Initial(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Contact_Name(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Last_Update_Contact_Initial(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => String.Compare(c.Province_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }

        // Number Functions
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Counter(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_ID(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Lat(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Lng(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Area_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Area_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Area_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Area_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Sector_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Sector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Sector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Sector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Subsector_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Subsector_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Subsector_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Subsector_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Municipality_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Municipality_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Municipality_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Municipality_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Lift_Station_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Lift_Station_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Lift_Station_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Lift_Station_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_WWTP_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_WWTP_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_WWTP_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_WWTP_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_MWQM_Sample_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_MWQM_Site_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_MWQM_Run_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Run_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Run_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_MWQM_Run_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Pol_Source_Site_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Pol_Source_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Pol_Source_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Pol_Source_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Mike_Scenario_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Mike_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Mike_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Mike_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Box_Model_Scenario_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
        public IQueryable<ReportProvinceModel> ReportServiceGeneratedProvince_Province_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportProvinceModel> reportProvinceModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportProvinceModelQ = reportProvinceModelQ.Where(c => c.Province_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportProvinceModelQ;
        }
    }
}
