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
    public partial class ReportServiceCountry_File
    {
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Country_File_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Error);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Error);
                            }
                            break;
                        case "Country_File_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Counter);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Counter);
                            }
                            break;
                        case "Country_File_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_ID);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_ID);
                            }
                            break;
                        case "Country_File_Language":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Language);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Language);
                            }
                            break;
                        case "Country_File_Purpose":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Purpose);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Purpose);
                            }
                            break;
                        case "Country_File_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Type);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Type);
                            }
                            break;
                        case "Country_File_Description":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Description);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Description);
                            }
                            break;
                        case "Country_File_Size_kb":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Size_kb);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Size_kb);
                            }
                            break;
                        case "Country_File_Info":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Info);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Info);
                            }
                            break;
                        case "Country_File_Created_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Created_Date_UTC);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Created_Date_UTC);
                            }
                            break;
                        case "Country_File_From_Water":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_From_Water);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_From_Water);
                            }
                            break;
                        case "Country_File_Server_File_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Server_File_Name);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Server_File_Name);
                            }
                            break;
                        case "Country_File_Server_File_Path":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Server_File_Path);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Server_File_Path);
                            }
                            break;
                        case "Country_File_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Last_Update_Date_And_Time_UTC);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Country_File_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Last_Update_Contact_Name);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Last_Update_Contact_Name);
                            }
                            break;
                        case "Country_File_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderBy(c => c.Country_File_Last_Update_Contact_Initial);
                                else
                                    reportCountry_FileModelQ = reportCountry_FileModelQ.OrderByDescending(c => c.Country_File_Last_Update_Contact_Initial);
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
                        case "Country_File_Created_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_YEAR(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_MONTH(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_DAY(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_HOUR(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_MINUTE(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Country_File_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_YEAR(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_MONTH(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_DAY(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_HOUR(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_MINUTE(reportCountry_FileModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Country_File_Error":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Error(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_File_Description":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Description(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_File_Info":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Info(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_File_Server_File_Name":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Server_File_Name(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_File_Server_File_Path":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Server_File_Path(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_File_Last_Update_Contact_Name":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Contact_Name(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Country_File_Last_Update_Contact_Initial":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Last_Update_Contact_Initial(reportCountry_FileModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Country_File_Counter":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Counter(reportCountry_FileModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_File_ID":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_ID(reportCountry_FileModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Country_File_Size_kb":
                            reportCountry_FileModelQ = ReportServiceGeneratedCountry_File_Country_File_Size_kb(reportCountry_FileModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Country_File_From_Water":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_From_Water == true);
                            else
                                reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_From_Water == false);
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
                        case "Country_File_Purpose":
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
                                reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => FilePurposeEqualList.Contains((FilePurposeEnum)c.Country_File_Purpose));
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
                        case "Country_File_Type":
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
                                reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => FileTypeEqualList.Contains((FileTypeEnum)c.Country_File_Type));
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
                        case "Country_File_Language":
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
                                reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => LanguageEqualList.Contains((LanguageEnum)c.Country_File_Language));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LanguageEnum
            return reportCountry_FileModelQ;
        }

        // Date Functions
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_YEAR(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_MONTH(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_DAY(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_HOUR(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Created_Date_UTC_MINUTE(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Created_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportCountry_FileModelQ;
        }

        // Text Functions
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Error(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Description(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Description.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Description.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Description.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Description.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Description.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Info(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Info.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Info.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Info.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Info.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Info.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Info.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Server_File_Name(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Server_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Server_File_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Server_File_Path(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Path.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Path.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Path.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Server_File_Path.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Server_File_Path.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Server_File_Path.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Contact_Name(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Last_Update_Contact_Initial(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => String.Compare(c.Country_File_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }

        // Number Functions
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Counter(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_ID(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
        public IQueryable<ReportCountry_FileModel> ReportServiceGeneratedCountry_File_Country_File_Size_kb(IQueryable<ReportCountry_FileModel> reportCountry_FileModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Size_kb > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Size_kb < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportCountry_FileModelQ = reportCountry_FileModelQ.Where(c => c.Country_File_Size_kb == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportCountry_FileModelQ;
        }
    }
}
