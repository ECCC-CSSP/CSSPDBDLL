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
    public partial class ReportServiceMike_Scenario_File
    {
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Scenario_File_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Error);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Error);
                            }
                            break;
                        case "Mike_Scenario_File_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Counter);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Counter);
                            }
                            break;
                        case "Mike_Scenario_File_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_ID);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_ID);
                            }
                            break;
                        case "Mike_Scenario_File_Language":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Language);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Language);
                            }
                            break;
                        case "Mike_Scenario_File_Purpose":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Purpose);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Purpose);
                            }
                            break;
                        case "Mike_Scenario_File_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Type);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Type);
                            }
                            break;
                        case "Mike_Scenario_File_Description":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Description);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Description);
                            }
                            break;
                        case "Mike_Scenario_File_Size_kb":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Size_kb);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Size_kb);
                            }
                            break;
                        case "Mike_Scenario_File_Info":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Info);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Info);
                            }
                            break;
                        case "Mike_Scenario_File_Created_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Created_Date_UTC);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Created_Date_UTC);
                            }
                            break;
                        case "Mike_Scenario_File_From_Water":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_From_Water);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_From_Water);
                            }
                            break;
                        case "Mike_Scenario_File_Server_File_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Server_File_Name);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Server_File_Name);
                            }
                            break;
                        case "Mike_Scenario_File_Server_File_Path":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Server_File_Path);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Server_File_Path);
                            }
                            break;
                        case "Mike_Scenario_File_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Mike_Scenario_File_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Last_Update_Contact_Name);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Last_Update_Contact_Name);
                            }
                            break;
                        case "Mike_Scenario_File_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderBy(c => c.Mike_Scenario_File_Last_Update_Contact_Initial);
                                else
                                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.OrderByDescending(c => c.Mike_Scenario_File_Last_Update_Contact_Initial);
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
                        case "Mike_Scenario_File_Created_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_YEAR(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_MONTH(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_DAY(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_HOUR(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_MINUTE(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Mike_Scenario_File_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_YEAR(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_MONTH(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_DAY(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_HOUR(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_MINUTE(reportMike_Scenario_FileModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Mike_Scenario_File_Error":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Error(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_File_Description":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Description(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_File_Info":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Info(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_File_Server_File_Name":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Server_File_Name(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_File_Server_File_Path":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Server_File_Path(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_File_Last_Update_Contact_Name":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Contact_Name(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Mike_Scenario_File_Last_Update_Contact_Initial":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Contact_Initial(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Mike_Scenario_File_Counter":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Counter(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_File_ID":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_ID(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Mike_Scenario_File_Size_kb":
                            reportMike_Scenario_FileModelQ = ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Size_kb(reportMike_Scenario_FileModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Mike_Scenario_File_From_Water":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_From_Water == true);
                            else
                                reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_From_Water == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            #region Filter FilePurposeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.FilePurpose))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Scenario_File_Purpose":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<FilePurposeEnum> FilePurposeEqualList = new List<FilePurposeEnum>();
                                List<string> FilePurposeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in FilePurposeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(FilePurposeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((FilePurposeEnum)i).ToString())
                                        {
                                            FilePurposeEqualList.Add((FilePurposeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        FilePurposeEqualList.Add(FilePurposeEnum.Error);
                                }
                                reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => FilePurposeEqualList.Contains((FilePurposeEnum)c.Mike_Scenario_File_Purpose));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter FilePurposeEnum
            #region Filter FileTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.FileType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Scenario_File_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<FileTypeEnum> FileTypeEqualList = new List<FileTypeEnum>();
                                List<string> FileTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in FileTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(FileTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((FileTypeEnum)i).ToString())
                                        {
                                            FileTypeEqualList.Add((FileTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        FileTypeEqualList.Add(FileTypeEnum.Error);
                                }
                                reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => FileTypeEqualList.Contains((FileTypeEnum)c.Mike_Scenario_File_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter FileTypeEnum
            #region Filter LanguageEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.Language))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Mike_Scenario_File_Language":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<LanguageEnum> LanguageEqualList = new List<LanguageEnum>();
                                List<string> LanguageTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in LanguageTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(LanguageEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((LanguageEnum)i).ToString())
                                        {
                                            LanguageEqualList.Add((LanguageEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        LanguageEqualList.Add(LanguageEnum.Error);
                                }
                                reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => LanguageEqualList.Contains((LanguageEnum)c.Mike_Scenario_File_Language));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LanguageEnum
            return reportMike_Scenario_FileModelQ;
        }

        // Date Functions
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_YEAR(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_MONTH(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_DAY(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_HOUR(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Created_Date_UTC_MINUTE(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMike_Scenario_FileModelQ;
        }

        // Text Functions
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Error(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Description(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Description.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Description.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Description.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Description.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Info(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Info.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Info.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Info.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Info.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Info.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Info.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Server_File_Name(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Server_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Server_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Server_File_Path(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Path.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Path.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Path.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Server_File_Path.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Server_File_Path.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Server_File_Path.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Contact_Name(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Last_Update_Contact_Initial(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => String.Compare(c.Mike_Scenario_File_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }

        // Number Functions
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Counter(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_ID(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
        public IQueryable<ReportMike_Scenario_FileModel> ReportServiceGeneratedMike_Scenario_File_Mike_Scenario_File_Size_kb(IQueryable<ReportMike_Scenario_FileModel> reportMike_Scenario_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Size_kb > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Size_kb < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMike_Scenario_FileModelQ = reportMike_Scenario_FileModelQ.Where(c => c.Mike_Scenario_File_Size_kb == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMike_Scenario_FileModelQ;
        }
    }
}
