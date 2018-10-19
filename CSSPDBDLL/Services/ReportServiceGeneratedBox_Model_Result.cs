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
    public partial class ReportServiceBox_Model_Result
    {
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Box_Model_Result_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Error);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Error);
                            }
                            break;
                        case "Box_Model_Result_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Counter);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Counter);
                            }
                            break;
                        case "Box_Model_Result_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_ID);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_ID);
                            }
                            break;
                        case "Box_Model_Result_Result_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Result_Type);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Result_Type);
                            }
                            break;
                        case "Box_Model_Result_Volume_m3":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Volume_m3);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Volume_m3);
                            }
                            break;
                        case "Box_Model_Result_Surface_m2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Surface_m2);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Surface_m2);
                            }
                            break;
                        case "Box_Model_Result_Radius_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Radius_m);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Radius_m);
                            }
                            break;
                        case "Box_Model_Result_Left_Side_Diameter_Line_Angle_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Left_Side_Diameter_Line_Angle_deg);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Left_Side_Diameter_Line_Angle_deg);
                            }
                            break;
                        case "Box_Model_Result_Circle_Center_Latitude":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Circle_Center_Latitude);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Circle_Center_Latitude);
                            }
                            break;
                        case "Box_Model_Result_Circle_Center_Longitude":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Circle_Center_Longitude);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Circle_Center_Longitude);
                            }
                            break;
                        case "Box_Model_Result_Fix_Length":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Fix_Length);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Fix_Length);
                            }
                            break;
                        case "Box_Model_Result_Fix_Width":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Fix_Width);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Fix_Width);
                            }
                            break;
                        case "Box_Model_Result_Rect_Length_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Rect_Length_m);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Rect_Length_m);
                            }
                            break;
                        case "Box_Model_Result_Rect_Width_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Rect_Width_m);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Rect_Width_m);
                            }
                            break;
                        case "Box_Model_Result_Left_Side_Line_Angle_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Left_Side_Line_Angle_deg);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Left_Side_Line_Angle_deg);
                            }
                            break;
                        case "Box_Model_Result_Left_Side_Line_Start_Latitude":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Left_Side_Line_Start_Latitude);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Left_Side_Line_Start_Latitude);
                            }
                            break;
                        case "Box_Model_Result_Left_Side_Line_Start_Longitude":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Left_Side_Line_Start_Longitude);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Left_Side_Line_Start_Longitude);
                            }
                            break;
                        case "Box_Model_Result_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Last_Update_Date_UTC);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Last_Update_Date_UTC);
                            }
                            break;
                        case "Box_Model_Result_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Last_Update_Contact_Name);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Last_Update_Contact_Name);
                            }
                            break;
                        case "Box_Model_Result_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderBy(c => c.Box_Model_Result_Last_Update_Contact_Initial);
                                else
                                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.OrderByDescending(c => c.Box_Model_Result_Last_Update_Contact_Initial);
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
                        case "Box_Model_Result_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_YEAR(reportBox_Model_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_MONTH(reportBox_Model_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_DAY(reportBox_Model_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_HOUR(reportBox_Model_ResultModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_MINUTE(reportBox_Model_ResultModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Box_Model_Result_Error":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Error(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Box_Model_Result_Last_Update_Contact_Name":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Contact_Name(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Box_Model_Result_Last_Update_Contact_Initial":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Contact_Initial(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Box_Model_Result_Counter":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Counter(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_ID":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_ID(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Volume_m3":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Volume_m3(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Surface_m2":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Surface_m2(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Radius_m":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Radius_m(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Left_Side_Diameter_Line_Angle_deg":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Diameter_Line_Angle_deg(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Circle_Center_Latitude":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Circle_Center_Latitude(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Circle_Center_Longitude":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Circle_Center_Longitude(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Rect_Length_m":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Rect_Length_m(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Rect_Width_m":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Rect_Width_m(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Left_Side_Line_Angle_deg":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Line_Angle_deg(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Left_Side_Line_Start_Latitude":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Line_Start_Latitude(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Box_Model_Result_Left_Side_Line_Start_Longitude":
                            reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Line_Start_Longitude(reportBox_Model_ResultModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Box_Model_Result_Fix_Length":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Fix_Length == true);
                            else
                                reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Fix_Length == false);
                            break;
                        case "Box_Model_Result_Fix_Width":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Fix_Width == true);
                            else
                                reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Fix_Width == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            #region Filter BoxModelResultTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.BoxModelResultType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Box_Model_Result_Result_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<BoxModelResultTypeEnum> BoxModelResultTypeEqualList = new List<BoxModelResultTypeEnum>();
                                List<string> BoxModelResultTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in BoxModelResultTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(BoxModelResultTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((BoxModelResultTypeEnum)i).ToString())
                                        {
                                            BoxModelResultTypeEqualList.Add((BoxModelResultTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        BoxModelResultTypeEqualList.Add(BoxModelResultTypeEnum.Error);
                                }
                                reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => BoxModelResultTypeEqualList.Contains((BoxModelResultTypeEnum)c.Box_Model_Result_Result_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter BoxModelResultTypeEnum
            return reportBox_Model_ResultModelQ;
        }

        // Date Functions
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_YEAR(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_MONTH(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_DAY(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_HOUR(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Date_UTC_MINUTE(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportBox_Model_ResultModelQ;
        }

        // Text Functions
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Error(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => String.Compare(c.Box_Model_Result_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => String.Compare(c.Box_Model_Result_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Contact_Name(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => String.Compare(c.Box_Model_Result_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => String.Compare(c.Box_Model_Result_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Last_Update_Contact_Initial(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => String.Compare(c.Box_Model_Result_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => String.Compare(c.Box_Model_Result_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }

        // Number Functions
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Counter(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_ID(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Volume_m3(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Volume_m3 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Volume_m3 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Volume_m3 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Surface_m2(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Surface_m2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Surface_m2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Surface_m2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Radius_m(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Radius_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Radius_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Radius_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Diameter_Line_Angle_deg(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Diameter_Line_Angle_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Diameter_Line_Angle_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Diameter_Line_Angle_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Circle_Center_Latitude(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Circle_Center_Latitude > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Circle_Center_Latitude < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Circle_Center_Latitude == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Circle_Center_Longitude(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Circle_Center_Longitude > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Circle_Center_Longitude < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Circle_Center_Longitude == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Rect_Length_m(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Rect_Length_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Rect_Length_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Rect_Length_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Rect_Width_m(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Rect_Width_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Rect_Width_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Rect_Width_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Line_Angle_deg(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Angle_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Angle_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Angle_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Line_Start_Latitude(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Start_Latitude > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Start_Latitude < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Start_Latitude == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
        public IQueryable<ReportBox_Model_ResultModel> ReportServiceGeneratedBox_Model_Result_Box_Model_Result_Left_Side_Line_Start_Longitude(IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Start_Longitude > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Start_Longitude < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportBox_Model_ResultModelQ = reportBox_Model_ResultModelQ.Where(c => c.Box_Model_Result_Left_Side_Line_Start_Longitude == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportBox_Model_ResultModelQ;
        }
    }
}
