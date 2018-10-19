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
    public partial class ReportServiceSubsector_Tide_Site
    {
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Tide_Site_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Error);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Error);
                            }
                            break;
                        case "Subsector_Tide_Site_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Counter);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Counter);
                            }
                            break;
                        case "Subsector_Tide_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_ID);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_ID);
                            }
                            break;
                        case "Subsector_Tide_Site_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Name_Translation_Status);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Name_Translation_Status);
                            }
                            break;
                        case "Subsector_Tide_Site_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Name);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Name);
                            }
                            break;
                        case "Subsector_Tide_Site_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Is_Active);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Is_Active);
                            }
                            break;
                        case "Subsector_Tide_Site_Web_Tide_Model":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Web_Tide_Model);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Web_Tide_Model);
                            }
                            break;
                        case "Subsector_Tide_Site_Web_Tide_Datum_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Web_Tide_Datum_m);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Web_Tide_Datum_m);
                            }
                            break;
                        case "Subsector_Tide_Site_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Subsector_Tide_Site_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Tide_Site_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Subsector_Tide_Site_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Lat);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Lat);
                            }
                            break;
                        case "Subsector_Tide_Site_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderBy(c => c.Subsector_Tide_Site_Lng);
                                else
                                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.OrderByDescending(c => c.Subsector_Tide_Site_Lng);
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
                        case "Subsector_Tide_Site_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_YEAR(reportSubsector_Tide_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_MONTH(reportSubsector_Tide_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_DAY(reportSubsector_Tide_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_HOUR(reportSubsector_Tide_SiteModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_MINUTE(reportSubsector_Tide_SiteModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Tide_Site_Error":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Error(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Tide_Site_Name":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Name(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Tide_Site_Web_Tide_Model":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Web_Tide_Model(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Tide_Site_Last_Update_Contact_Name":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Contact_Name(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Tide_Site_Last_Update_Contact_Initial":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Contact_Initial(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Tide_Site_Counter":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Counter(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_ID":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_ID(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Web_Tide_Datum_m":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Web_Tide_Datum_m(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Lat":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Lat(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Tide_Site_Lng":
                            reportSubsector_Tide_SiteModelQ = ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Lng(reportSubsector_Tide_SiteModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Tide_Site_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Is_Active == true);
                            else
                                reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Is_Active == false);
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
                        case "Subsector_Tide_Site_Name_Translation_Status":
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
                                reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Subsector_Tide_Site_Name_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            return reportSubsector_Tide_SiteModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Tide_SiteModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Error(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Name(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Web_Tide_Model(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Model.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Model.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Model.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Model.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Web_Tide_Model.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Web_Tide_Model.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Contact_Name(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => String.Compare(c.Subsector_Tide_Site_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Counter(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_ID(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Web_Tide_Datum_m(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Datum_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Datum_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Web_Tide_Datum_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Lat(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
        public IQueryable<ReportSubsector_Tide_SiteModel> ReportServiceGeneratedSubsector_Tide_Site_Subsector_Tide_Site_Lng(IQueryable<ReportSubsector_Tide_SiteModel> reportSubsector_Tide_SiteModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Tide_SiteModelQ = reportSubsector_Tide_SiteModelQ.Where(c => c.Subsector_Tide_Site_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Tide_SiteModelQ;
        }
    }
}
